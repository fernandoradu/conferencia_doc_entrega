using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using ExercicioFinalRadu.Resources;
//using System.Windows.Forms;

namespace ExercicioFinalRadu
{
    class Menu
    {
        public void AddMenuItems()
        {
            String xmlMenu;
            try
            {
                RemoveMenu();

                xmlMenu = Resources.Menu.menuadd.ToString().Replace("%path%", Environment.CurrentDirectory);
                Application.SBO_Application.LoadBatchActions(ref xmlMenu);
            }
            catch
            {
                throw;
            }
        }
        public void RemoveMenu()
        {
            String xmlMenu;

            try
            {
                xmlMenu = Resources.Menu.menuremove.ToString().Replace("%path%", Environment.CurrentDirectory);
                Application.SBO_Application.LoadBatchActions(ref xmlMenu);
            }
            catch
            {
                throw;
            }
        }
        public void SBO_Application_MenuEvent(ref SAPbouiCOM.MenuEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

            try
            {
                if (pVal.BeforeAction && pVal.MenuUID == "mnu_Entrega")
                {
                    //System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                    FormSeparacao activeForm = new FormSeparacao();
                    activeForm.Show();                    
                }                              
            }
            catch (Exception ex)
            {
                Application.SBO_Application.MessageBox(ex.ToString(), 1, "Ok", "", "");
            }
        }

    }
}
