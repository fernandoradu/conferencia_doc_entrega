using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace ExercicioFinalRadu
{
    [FormAttribute("ExercicioFinalRadu.FormSeparacao", "FormSeparacao.b1f")]
    class FormSeparacao : UserFormBase
    {
        public FormSeparacao()
        {
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.lblCodeBP = ((SAPbouiCOM.StaticText)(this.GetItem("lblCodeBP").Specific));
            this.lblDataDe = ((SAPbouiCOM.StaticText)(this.GetItem("lblDataDe").Specific));
            this.lblDataAte = ((SAPbouiCOM.StaticText)(this.GetItem("lblDataAte").Specific));
            this.lblNomePN = ((SAPbouiCOM.StaticText)(this.GetItem("lblNomePN").Specific));
            this.lblVendedo = ((SAPbouiCOM.StaticText)(this.GetItem("lblVendedo").Specific));
            this.lblEntDe = ((SAPbouiCOM.StaticText)(this.GetItem("lblEntDe").Specific));
            this.lblEntAte = ((SAPbouiCOM.StaticText)(this.GetItem("lblEntAte").Specific));
            this.txtCodeBP = ((SAPbouiCOM.EditText)(this.GetItem("txtCodeBP").Specific));
            this.txtDataDe = ((SAPbouiCOM.EditText)(this.GetItem("txtDataDe").Specific));
            this.txtDataAte = ((SAPbouiCOM.EditText)(this.GetItem("txtDataAte").Specific));
            this.txtNomePN = ((SAPbouiCOM.EditText)(this.GetItem("txtNomePN").Specific));
            this.txtVendedo = ((SAPbouiCOM.EditText)(this.GetItem("txtVendedo").Specific));
            this.txtNomeVen = ((SAPbouiCOM.EditText)(this.GetItem("txtNomeVen").Specific));
            this.txtEntDe = ((SAPbouiCOM.EditText)(this.GetItem("txtEntDe").Specific));
            this.txtEntAte = ((SAPbouiCOM.EditText)(this.GetItem("txtEntAte").Specific));
            this.btnListar = ((SAPbouiCOM.Button)(this.GetItem("btnListar").Specific));
            this.btnListar.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.btnListar_PressedAfter);
            this.btnCancel = ((SAPbouiCOM.Button)(this.GetItem("btnCancel").Specific));
            this.btnCancel.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.btnCancel_PressedAfter);
            this.btnGerar = ((SAPbouiCOM.Button)(this.GetItem("btnGerar").Specific));
            this.btnGerar.PressedBefore += new SAPbouiCOM._IButtonEvents_PressedBeforeEventHandler(this.btnGerar_PressedBefore);
            this.btnGerar.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.btnGerar_PressedAfter);
            this.mtxEntrega = ((SAPbouiCOM.Matrix)(this.GetItem("mtxEntrega").Specific));
            this.lnkCodeBP = ((SAPbouiCOM.LinkedButton)(this.GetItem("lnkCodeBP").Specific));
            this.lnkEmpID = ((SAPbouiCOM.LinkedButton)(this.GetItem("lnkEmpID").Specific));
            this.txtCodeBP.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.event_ChooseFromListAfter);
            this.txtNomePN.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.event_ChooseFromListAfter);
            this.txtVendedo.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.event_ChooseFromListAfter);
            this.txtNomeVen.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.event_ChooseFromListAfter);
            this.txtEntDe.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.event_ChooseFromListAfter);
            this.txtEntAte.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.event_ChooseFromListAfter);
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
        }        

        private void OnCustomInitialize()
        {
            
            this.mtxEntrega.AutoResizeColumns();

            this.OnInitializeFormEvents();
            /*Aplicacao de Filtro no ChooseFromList*/
            SAPbouiCOM.Conditions oCons = null;
            SAPbouiCOM.Condition oCon = null;

            oCons = this.UIAPIRawForm.ChooseFromLists.Item("cflBP").GetConditions();
            oCon = oCons.Add();

            oCon.Alias = "CardType";
            oCon.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
            oCon.CondVal = "C";

            this.UIAPIRawForm.ChooseFromLists.Item("cflBP").SetConditions(oCons);
            
        }

        private void event_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.ISBOChooseFromListEventArg oCFLEvent = null;
     
            oCFLEvent = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;

            SAPbouiCOM.DataTable oDataTable = oCFLEvent.SelectedObjects;

            if (oDataTable == null)
                return;

            if ( oDataTable.UniqueID == "cflBP" || oDataTable.UniqueID == "cflBPName" )
            {
                var code = oDataTable.GetValue("CardCode", 0).ToString();
                var name = oDataTable.GetValue("CardName", 0).ToString();
                this.UIAPIRawForm.DataSources.UserDataSources.Item("udCardCode").Value = code;
                this.UIAPIRawForm.DataSources.UserDataSources.Item("udCardName").Value = name;
            }
            else if (oDataTable.UniqueID == "cflEmploye" || oDataTable.UniqueID == "cflEmpName")
            {
                var code = oDataTable.GetValue("Code", 0).ToString();
                var name = oDataTable.GetValue("firstName", 0).ToString();
                
                if (oDataTable.GetValue("middleName", 0).ToString() != "")
                    name += " " + oDataTable.GetValue("middleName", 0).ToString(); 
                
                name += " " + oDataTable.GetValue("lastName", 0).ToString();
                
                this.UIAPIRawForm.DataSources.UserDataSources.Item("udEmpID").Value = code;
                this.UIAPIRawForm.DataSources.UserDataSources.Item("udNameEmp").Value = name;
            }
            else if (oDataTable.UniqueID == "cflEntDe")
            {
                var code = oDataTable.GetValue("DocNum", 0).ToString();
                this.UIAPIRawForm.DataSources.UserDataSources.Item("udEntDe").Value = code;
            }
            else if (oDataTable.UniqueID == "cflEntAte")
            {
                var code = oDataTable.GetValue("DocNum", 0).ToString();
                this.UIAPIRawForm.DataSources.UserDataSources.Item("udEntAte").Value = code;
            }
        }

        private void btnListar_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {

            StringBuilder query = new StringBuilder();
            string dataDe;
            string dataAte;

            query.Append("SELECT");
            query.Append("  \"DocEntry\",");
            query.Append("  \"DocNum\",");
            query.Append("  \"CardCode\",");
            query.Append("  \"DocDueDate\",");
            query.Append("  \"DocTotal\" ");
            query.Append("FROM");
            query.Append("  ODLN DOC_ENT ");
            query.Append("WHERE");
            query.Append("  \"CANCELED\" = 'N'");
            query.Append("  AND \"DocStatus\" = 'O' ");

            if ( !(string.IsNullOrEmpty(txtEntDe.String)) || !(string.IsNullOrEmpty(txtEntAte.String)))
            {
                query.AppendFormat("    AND \"DocNum\" BETWEEN {0} AND {1}", 
                        (String.IsNullOrEmpty(txtEntDe.String) ? "0": txtEntDe.String),
                        (String.IsNullOrEmpty(txtEntAte.String) ? "99999" : txtEntAte.String));                
            }
            
            if (!(string.IsNullOrEmpty(txtDataDe.String)) || !(string.IsNullOrEmpty(txtDataAte.String)))
            {
                dataDe = txtDataDe.String.Replace('/', '-');                                                                    
                dataDe = dataDe.Substring(6,4) + '-' + dataDe.Substring(3, 2) + '-' + dataDe.Substring(0,2);    //21-05-2024    
                dataAte = txtDataAte.String.Replace('/', '-');
                dataAte = dataAte.Substring(6, 4) + '-' + dataAte.Substring(3, 2) + '-' + dataAte.Substring(0, 2);    //21-05-2024                    
                
                query.AppendFormat("  AND \"DocDueDate\" BETWEEN '{0}' AND '{1}' ", dataDe, dataAte);
            }
            
            if ( !(string.IsNullOrEmpty(txtCodeBP.String)) )
                query.AppendFormat("  AND \"CardCode\" = '{0}' ", txtCodeBP.String);                
            
            if ( !(string.IsNullOrEmpty(txtVendedo.String)) )
                query.AppendFormat("  AND \"SlpCode\" = '{0}' ", txtVendedo.String);

            try
            {

                this.UIAPIRawForm.DataSources.DataTables.Item("dtListEnt").ExecuteQuery(query.ToString());

                mtxEntrega.Columns.Item("cDocEntry").DataBind.Bind("dtListEnt", "DocEntry");
                mtxEntrega.Columns.Item("cDocNum").DataBind.Bind("dtListEnt", "DocNum");
                mtxEntrega.Columns.Item("cCardCode").DataBind.Bind("dtListEnt", "CardCode");
                mtxEntrega.Columns.Item("cDocDate").DataBind.Bind("dtListEnt", "DocDueDate");
                mtxEntrega.Columns.Item("cDocTotal").DataBind.Bind("dtListEnt", "DocTotal");
                
                UIAPIRawForm.Freeze(true);
                mtxEntrega.LoadFromDataSource();
                UIAPIRawForm.Freeze(false);

                //mtxEntrega.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                Application.SBO_Application.MessageBox(ex.Message);
            }

        }
        private void btnCancel_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            Application.SBO_Application.Forms.ActiveForm.Close();
            //System.Windows.Forms.Application.Exit();
        }
        private void btnGerar_PressedBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = false;
            
            for (int row = 1; row <= mtxEntrega.RowCount; row++)
            {
                if ( ((SAPbouiCOM.CheckBox)mtxEntrega.Columns.Item(0).Cells.Item(row).Specific).Checked)
                {
                    BubbleEvent = true;
                    return;
                }
            }
            Application.SBO_Application.SetStatusBarMessage("Nenhum documento de entrega foi selecionado.", SAPbouiCOM.BoMessageTime.bmt_Short, true);
        }
        private void btnGerar_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            this.IncluiNotaSaida();
            this.btnListar_PressedAfter(sboObject,pVal);
        }

        private void IncluiNotaSaida()
        {
            int ret = 0;
            List<int> removeFromMatrix = new List<int>();
            
            SAPbouiCOM.ProgressBar oProgress = Application.SBO_Application.StatusBar.CreateProgressBar("Incluindo Notas", mtxEntrega.RowCount, false);
            try
            {
                oInvoice        = (SAPbobsCOM.Documents)oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oInvoices);
                oDeliverySales  = (SAPbobsCOM.Documents)oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oDeliveryNotes);


                for (int row = 1; row <= mtxEntrega.RowCount; row++)
                {
                    SAPbouiCOM.CheckBox _check = (SAPbouiCOM.CheckBox)mtxEntrega.Columns.Item(0).Cells.Item(row).Specific;
                    SAPbouiCOM.EditText edit = (SAPbouiCOM.EditText)mtxEntrega.Columns.Item("cDocEntry").Cells.Item(row).Specific;
                
                    //((SAPbouiCOM.EditText)Matrix6.Columns.Item("Col_0").Cells.Item(pVal.Row).Specific).String;
                    if ( _check.Checked )
                    {
                    
                        if ( oDeliverySales.GetByKey((int.Parse(edit.Value))) )
                        { 
                            oInvoice.CardCode = oDeliverySales.CardCode;
                            oInvoice.Comments = "Executado pelo addon do Radu";
                            oInvoice.TaxExtension.MainUsage = 10;

                            for (int line = 0; line < oDeliverySales.Lines.Count; line++)
                            {
                                oDeliverySales.Lines.SetCurrentLine(line);

                                oInvoice.Lines.BaseEntry = Convert.ToInt32(oDeliverySales.DocEntry);
                                oInvoice.Lines.BaseLine = oDeliverySales.Lines.LineNum;
                                oInvoice.Lines.BaseType = (Int32)SAPbobsCOM.BoObjectTypes.oDeliveryNotes;

                                if (line + 1 != oDeliverySales.Lines.Count)
                                    oInvoice.Lines.Add();
                            
                            }
                            //Inclui o documento de saída
                            ret = oInvoice.Add();

                            if (ret != 0)
                                throw new Exception(oComp.GetLastErrorDescription() + " Entrega nrp: " + edit.Value.ToString()); //TODO: Acrescentar nro da Entrega
                            else
                            {
                                oProgress.Text = "Nota da Entrega nro: " + edit.Value.ToString() + " gerada com sucesso. Nota: " + oComp.GetNewObjectKey(); ;
                                removeFromMatrix.Add(row); //acrescebta em uma lista a linha da matriz que será removida
                            }
                        }                    
                    }
                
                    oProgress.Value++;
                }
            
                //if ( removeFromMatrix.Count > 0 )
                //{
                //    for (int ind = 0; ind < removeFromMatrix.Count; ind++)
                //    {
                //        mtxEntrega.DeleteRow(removeFromMatrix[ind]);
                //    }
                //}
                //System.Runtime.InteropServices.Marshal.ReleaseComObject(oProgress);                
            }
            catch (Exception ex)
            {
                _hasError = true;
                _msgError = ex.Message;
                Application.SBO_Application.SetStatusBarMessage(ex.Message, SAPbouiCOM.BoMessageTime.bmt_Short, true);
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oProgress);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oInvoice);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oDeliverySales);
            }
        }

        private SAPbouiCOM.StaticText lblCodeBP;
        private SAPbouiCOM.StaticText lblDataDe;
        private SAPbouiCOM.StaticText lblDataAte;
        private SAPbouiCOM.StaticText lblNomePN;
        private SAPbouiCOM.StaticText lblVendedo;
        private SAPbouiCOM.StaticText lblEntDe;
        private SAPbouiCOM.StaticText lblEntAte;
        private SAPbouiCOM.EditText txtCodeBP;
        private SAPbouiCOM.EditText txtDataDe;
        private SAPbouiCOM.EditText txtDataAte;
        private SAPbouiCOM.EditText txtNomePN;
        private SAPbouiCOM.EditText txtVendedo;
        private SAPbouiCOM.EditText txtNomeVen;
        private SAPbouiCOM.EditText txtEntDe;
        private SAPbouiCOM.EditText txtEntAte;
        private SAPbouiCOM.Button btnListar;
        private SAPbouiCOM.Button btnCancel;
        private SAPbouiCOM.Button btnGerar;
        private SAPbouiCOM.Matrix mtxEntrega;
        private SAPbouiCOM.LinkedButton lnkCodeBP;
        private SAPbouiCOM.LinkedButton lnkEmpID;

        private bool _hasError = false;
        private string _msgError = "";

        SAPbobsCOM.Documents oDeliverySales = null;
        SAPbobsCOM.Documents oInvoice = null;
        SAPbobsCOM.Company oComp = (SAPbobsCOM.Company)Application.SBO_Application.Company.GetDICompany();

    }
}