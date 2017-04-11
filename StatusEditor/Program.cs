using System;
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
                Application.ThreadException += new ThreadExceptionEventHandler(new ThreadExceptionHandler().ApplicationThreadException);
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

            public void ApplicationThreadException(object sender, ThreadExceptionEventArgs e)
            {

                StatusEditorForm.bError = true;
                AELogger.Log("Exception: " + e.Exception.Message);

                AELogger.Log("Exception: " + e.Exception.StackTrace);

                int i = 1;
                Exception a = e.Exception;
                while (a.InnerException != null)
                {
                    a = a.InnerException;
                    AELogger.Log("InnerException " + i + ": " + a.Message);

                    AELogger.Log("InnerException " + i + ": " + a.StackTrace);
                    i++;
                }
                Console.WriteLine(e.Exception.Message);
                MessageBox.Show("UNHAPPY ERROR :(\nyou should save the logfile.txt and give it to the developers of this tool \n--------------\n " +
                    e.Exception.Message + "\n" + e.Exception.StackTrace, "Exception!", MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);

                AELogger.WriteLog();
                Application.Exit();
            }
        }
    }
}
