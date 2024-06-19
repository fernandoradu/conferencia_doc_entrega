using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;

namespace ExercicioFinalRadu
{
    class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                Application oApp = null;
                
                if (args.Length < 1)
                {
                    oApp = new Application();
                }
                else
                {
                    //If you want to use an add-on identifier for the development license, you can specify an add-on identifier string as the second parameter.
                    //oApp = new Application(args[0], "XXXXX");
                    oApp = new Application(args[0]);
                }
                Menu MyMenu = new Menu();
                MyMenu.AddMenuItems();
                oApp.RegisterMenuEventHandler(MyMenu.SBO_Application_MenuEvent);
                Application.SBO_Application.AppEvent += new SAPbouiCOM._IApplicationEvents_AppEventEventHandler(SBO_Application_AppEvent);
                //Application.SBO_Application.FormDataEvent += SBO_Application_FormDataEvent;
                oApp.Run();
                                
                
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        //private static void SBO_Application_FormDataEvent(ref SAPbouiCOM.BusinessObjectInfo BusinessObjectInfo, out bool BubbleEvent)
        //{
        //    throw new NotImplementedException();
        //    BubbleEvent = true;

        //    if (BusinessObjectInfo.BeforeAction && BusinessObjectInfo.FormUID == "FRMSepara")
        //    {
        //        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
        //    }
        //    else if (BusinessObjectInfo.ActionSuccess && BusinessObjectInfo.FormUID == "FRMSepara" )
        //        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
        //}

        static void SBO_Application_AppEvent(SAPbouiCOM.BoAppEventTypes EventType)
        {
            switch (EventType)
            {
                case SAPbouiCOM.BoAppEventTypes.aet_ShutDown:
                    //Exit Add-On
                    System.Windows.Forms.Application.Exit();
                    break;
                case SAPbouiCOM.BoAppEventTypes.aet_CompanyChanged:
                    System.Windows.Forms.Application.Exit();
                    break;
                case SAPbouiCOM.BoAppEventTypes.aet_FontChanged:
                    System.Windows.Forms.Application.Exit();
                    break;
                case SAPbouiCOM.BoAppEventTypes.aet_LanguageChanged:
                    System.Windows.Forms.Application.Exit();
                    break;
                case SAPbouiCOM.BoAppEventTypes.aet_ServerTerminition:
                    System.Windows.Forms.Application.Exit();
                    Menu MyMenu = new Menu();
                    MyMenu.RemoveMenu();
                    break;
                default:
                    break;
            }
        }
    }
}
