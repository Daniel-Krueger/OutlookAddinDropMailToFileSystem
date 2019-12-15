//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MailAblage
//{
//    ///


//    /// The GlobalErrorHandler class ensures

//    /// that we have hooked all necessary

//    /// events to capture unhandled exceptions in our appdomains.

//    ///


//    static class GlobalErrorHandler

//    {

//        public static void Ensure()

//        {

//            // hook WinForms

//            System.Windows.Forms.Application.ThreadException += OnApplicationUnhandledException;

//            AppDomain.CurrentDomain.UnhandledException += OnDomainUnhandledException;

//        }



//        private static void OnApplicationUnhandledException(object sender, ThreadExceptionEventArgs e)

//        {

//            HandleException(e.Exception);

//        }



//        private static void OnDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)

//        {

//            HandleException((Exception)e.ExceptionObject);

//        }



//        private static void HandleException(Exception exp)

//        {

//            IErrorService errorSvc = AppContext.GetService<IErrorService>();

//            errorSvc.HandleError(exp);

//        }



//    } // class GlobalErrorHandler
//}
