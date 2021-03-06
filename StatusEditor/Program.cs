﻿using System;
using System.Threading;
using System.Windows.Forms;
using MarvelData;

namespace StatusEditor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AELogger.Prepare();

            try
            {
#if DEBUG
                TableFile.DataTest();
#endif
                AppDomain currentDomain = AppDomain.CurrentDomain;
                ThreadExceptionHandler handler = new ThreadExceptionHandler();
                currentDomain.UnhandledException += new UnhandledExceptionEventHandler(handler.ApplicationThreadException);
                Application.ThreadException += new ThreadExceptionEventHandler(handler.ApplicationThreadException);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new StatusEditorForm());
            }
            catch (Exception e)
            {
                StatusEditorForm.bError = true;

                AELogger.Log("Exception: " + e.Message);

                AELogger.Log("Exception: " + e.StackTrace);

                int i = 1;
                while (e.InnerException != null)
                {
                    e = e.InnerException;
                    AELogger.Log("InnerException " + i + ": " + e.Message);

                    AELogger.Log("InnerException " + i + ": " + e.StackTrace);
                    i++;
                }
                Console.WriteLine(e.Message);
                MessageBox.Show("UNHAPPY ERROR :(\nhey, you should save the logfile.txt and give it to the developers of this tool \n--------------\n " +
                    e.Message + "\n" + e.StackTrace, "Exception!", MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
            }

            AELogger.WriteLog();
        }


        public class ThreadExceptionHandler
        {
            public void HandleException(object sender, Exception e)
            {
                StatusEditorForm.bError = true;
                string exceptionString = "UNHAPPY ERROR :(\nyou should save the logfile.txt and give it to the developers of this tool \n--------------\n ";
                if (e == null)
                {
                    AELogger.Log("BIG PROBLEM, EXCEPTION IS NULL");
                    exceptionString += "BIG PROBLEM, EXCEPTION IS NULL\n";
                }
                else
                {
                    AELogger.Log("Exception: " + e.Message);

                    AELogger.Log("Exception: " + e.StackTrace);

                    int i = 1;
                    Exception a = e;
                    while (a.InnerException != null)
                    {
                        a = a.InnerException;
                        AELogger.Log("InnerException " + i + ": " + a.Message);

                        AELogger.Log("InnerException " + i + ": " + a.StackTrace);
                        i++;
                    }
                    Console.WriteLine(e.Message);
                    exceptionString += e.Message + "\n" + e.StackTrace + "\n";
                }

                if (sender != null)
                {
                    AELogger.Log("sender is " + sender.ToString());
                    exceptionString += "sender is " + sender.ToString();
                }
                else
                {
                    AELogger.Log("sender is null");
                    exceptionString += "sender is null";
                }
                MessageBox.Show(exceptionString, "Exception!", MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
                AELogger.WriteLog();
                Application.Exit();
            }

            public void ApplicationThreadException(object sender, UnhandledExceptionEventArgs e)
            {
                AELogger.Log("unhandled\ne.IsTerminating = " + e.IsTerminating);
                HandleException(sender, (Exception)e.ExceptionObject);
            }

            public void ApplicationThreadException(object sender, ThreadExceptionEventArgs e)
            {
                AELogger.Log("threadexception");
                HandleException(sender, e.Exception);
            }
        }
    }
}
