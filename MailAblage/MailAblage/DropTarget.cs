using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace MailAblage
{
    [ComImport, Guid("00000122-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IOleDropTarget
    {
        [PreserveSig]
        int OleDragEnter([In, MarshalAs(UnmanagedType.Interface)] object pDataObj, [In, MarshalAs(UnmanagedType.U4)] int grfKeyState, [In, MarshalAs(UnmanagedType.U8)] long pt, [In, Out] ref int pdwEffect);
        [PreserveSig]
        int OleDragOver([In, MarshalAs(UnmanagedType.U4)] int grfKeyState, [In, MarshalAs(UnmanagedType.U8)] long pt, [In, Out] ref int pdwEffect);
        [PreserveSig]
        int OleDragLeave();
        [PreserveSig]
        int OleDrop([In, MarshalAs(UnmanagedType.Interface)] object pDataObj, [In, MarshalAs(UnmanagedType.U4)] int grfKeyState, [In, MarshalAs(UnmanagedType.U8)] long pt, [In, Out] ref int pdwEffect);
    }

    internal class DropTarget : IOleDropTarget
    {
        private DragDropEffects lastEffect;
        private IDataObject dataObject = null;
        private IDropTarget owner;
        private IntPtr ownerHandle;

        [DllImport("ole32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern int RegisterDragDrop(IntPtr hwnd, IOleDropTarget target);

        [DllImport("ole32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern int RevokeDragDrop(IntPtr hwnd);

        public DropTarget(IDropTarget Owner)
        {
            owner = Owner;
        }

        public DropTarget(Control Owner)
        {
            owner = Owner;
            ownerHandle = Owner.Handle;
            if (Application.OleRequired() == System.Threading.ApartmentState.STA)
                RegisterDragDrop(ownerHandle, this);
        }

        public void Dispose()
        {
            if (ownerHandle != IntPtr.Zero)
                RevokeDragDrop(ownerHandle);
        }

        private void ReleaseDataObject(ref IDataObject data)
        {
            if (data != null)
            {
                object oleConverter = data.GetType().InvokeMember("innerData",
                    System.Reflection.BindingFlags.GetField | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance,
                    null, data, null);
                object sysDataObject = oleConverter.GetType().InvokeMember("innerData",
                    System.Reflection.BindingFlags.GetField | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance,
                    null, oleConverter, null);
                if (sysDataObject != null && Marshal.IsComObject(sysDataObject))
                    Marshal.ReleaseComObject(sysDataObject);
                data = null;
            }
        }

        private IDataObject GetDataObject(object pDataObj)
        {
            IDataObject result = null;
            if (pDataObj is IDataObject)
                result = (IDataObject)pDataObj;
            else
            {
                if (pDataObj is System.Runtime.InteropServices.ComTypes.IDataObject)
                    result = new DataObject(pDataObj);
            }
            return result;
        }

        int IOleDropTarget.OleDragEnter(object pDataObj, int grfKeyState, long pt, ref int pdwEffect)
        {
            dataObject = GetDataObject(pDataObj);
            DragEventArgs args = new DragEventArgs(dataObject, grfKeyState, GetX(pt), GetY(pt), (DragDropEffects)pdwEffect, this.lastEffect);
            if (args != null)
            {
                owner.OnDragEnter(args);
                pdwEffect = (int)args.Effect;
                this.lastEffect = args.Effect;
            }
            else
                pdwEffect = 0;
            return 0;
        }

        int IOleDropTarget.OleDragOver(int grfKeyState, long pt, ref int pdwEffect)
        {
            DragEventArgs args = new DragEventArgs(dataObject, grfKeyState, GetX(pt), GetY(pt), (DragDropEffects)pdwEffect, this.lastEffect);
            owner.OnDragOver(args);
            pdwEffect = (int)args.Effect;
            lastEffect = args.Effect;
            return 0;
        }

        int IOleDropTarget.OleDragLeave()
        {
            owner.OnDragLeave(EventArgs.Empty);
            ReleaseDataObject(ref dataObject);
            return 0;
        }

        int IOleDropTarget.OleDrop(object pDataObj, int grfKeyState, long pt, ref int pdwEffect)
        {
            if (pDataObj != null)
            {
                ReleaseDataObject(ref dataObject);
                dataObject = GetDataObject(pDataObj);
            }
            DragEventArgs args = new DragEventArgs(dataObject, grfKeyState, GetX(pt), GetY(pt), (DragDropEffects)pdwEffect, this.lastEffect);
            if (args != null)
            {
                owner.OnDragDrop(args);
                pdwEffect = (int)args.Effect;
            }
            else
                pdwEffect = 0;

            ReleaseDataObject(ref dataObject);
            lastEffect = DragDropEffects.None;
            return 0;
        }

        private int GetX(long pt)
        {
            return (int)(pt & (long)(-1));
        }

        private int GetY(long pt)
        {
            return (int)(pt >> 32 & (long)(-1));
        }
    }
}
