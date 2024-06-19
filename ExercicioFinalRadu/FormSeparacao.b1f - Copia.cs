using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
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
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("lblCodeBP").Specific));
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("lblDataDe").Specific));
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("lblDataAte").Specific));
            this.StaticText3 = ((SAPbouiCOM.StaticText)(this.GetItem("lblNomePar").Specific));
            this.StaticText4 = ((SAPbouiCOM.StaticText)(this.GetItem("lblVendedo").Specific));
            this.StaticText5 = ((SAPbouiCOM.StaticText)(this.GetItem("lblEntDe").Specific));
            this.StaticText6 = ((SAPbouiCOM.StaticText)(this.GetItem("lblEntAte").Specific));
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("txtCodeBP").Specific));
            this.EditText1 = ((SAPbouiCOM.EditText)(this.GetItem("txtDataDe").Specific));
            this.EditText2 = ((SAPbouiCOM.EditText)(this.GetItem("txtDataAte").Specific));
            this.EditText3 = ((SAPbouiCOM.EditText)(this.GetItem("Item_10").Specific));
            this.EditText4 = ((SAPbouiCOM.EditText)(this.GetItem("Item_11").Specific));
            this.EditText5 = ((SAPbouiCOM.EditText)(this.GetItem("Item_12").Specific));
            this.EditText6 = ((SAPbouiCOM.EditText)(this.GetItem("Item_13").Specific));
            this.EditText7 = ((SAPbouiCOM.EditText)(this.GetItem("Item_14").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("btnListar").Specific));
            this.Matrix0 = ((SAPbouiCOM.Matrix)(this.GetItem("Item_16").Specific));
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("Item_17").Specific));
            this.Button2 = ((SAPbouiCOM.Button)(this.GetItem("Item_18").Specific));
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
        }

        private SAPbouiCOM.StaticText StaticText0;

        private void OnCustomInitialize()
        {

        }

        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.StaticText StaticText3;
        private SAPbouiCOM.StaticText StaticText4;
        private SAPbouiCOM.StaticText StaticText5;
        private SAPbouiCOM.StaticText StaticText6;
        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.EditText EditText1;
        private SAPbouiCOM.EditText EditText2;
        private SAPbouiCOM.EditText EditText3;
        private SAPbouiCOM.EditText EditText4;
        private SAPbouiCOM.EditText EditText5;
        private SAPbouiCOM.EditText EditText6;
        private SAPbouiCOM.EditText EditText7;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Matrix Matrix0;
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.Button Button2;
    }
}