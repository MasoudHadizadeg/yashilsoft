// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 16.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace CodeGeneratorGreen.Templates.Angular.CRUD.ListForm
{
    using CodeGeneratorGreen.Classes;
    using CodeGeneratorGreen.Extentions;
    using CodeGeneratorGreen.Models;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "D:\Works\YashilSPL\CodeGeneratorGreen\CodeGeneratorGreen\Templates\Angular\CRUD\ListForm\AngularListForm.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class AngularListForm : AngularListFormBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("\t\t\t");
            
            #line 9 "D:\Works\YashilSPL\CodeGeneratorGreen\CodeGeneratorGreen\Templates\Angular\CRUD\ListForm\AngularListForm.tt"

			var table = SqlToCsharpHelper.table;
			string angularFriendlyName = table.Name.ToAngularFrendlyName();
			string firstCharacterLower = table.Name.FirstCharacterToLower();
			
            
            #line default
            #line hidden
            this.Write("\r\n\t\timport { Component, OnInit } from \'@angular/core\';\r\n\t\timport {");
            
            #line 16 "D:\Works\YashilSPL\CodeGeneratorGreen\CodeGeneratorGreen\Templates\Angular\CRUD\ListForm\AngularListForm.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(table.Name));
            
            #line default
            #line hidden
            this.Write("DetailComponent} from \'./");
            
            #line 16 "D:\Works\YashilSPL\CodeGeneratorGreen\CodeGeneratorGreen\Templates\Angular\CRUD\ListForm\AngularListForm.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(angularFriendlyName));
            
            #line default
            #line hidden
            this.Write("-detail.component\';\r\n\t\t");
            
            #line 17 "D:\Works\YashilSPL\CodeGeneratorGreen\CodeGeneratorGreen\Templates\Angular\CRUD\ListForm\AngularListForm.tt"

		if(table.GenerateTabForDescColumn){
		
            
            #line default
            #line hidden
            this.Write("\t\timport {");
            
            #line 20 "D:\Works\YashilSPL\CodeGeneratorGreen\CodeGeneratorGreen\Templates\Angular\CRUD\ListForm\AngularListForm.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(table.Name));
            
            #line default
            #line hidden
            this.Write("DetailTabBasedComponent} from \'./");
            
            #line 20 "D:\Works\YashilSPL\CodeGeneratorGreen\CodeGeneratorGreen\Templates\Angular\CRUD\ListForm\AngularListForm.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(angularFriendlyName));
            
            #line default
            #line hidden
            this.Write("-detail-tab-based.component\';\r\n\t\t");
            
            #line 21 "D:\Works\YashilSPL\CodeGeneratorGreen\CodeGeneratorGreen\Templates\Angular\CRUD\ListForm\AngularListForm.tt"
} 
            
            #line default
            #line hidden
            this.Write("\t\r\n\t\t\r\n\r\n\t\t@Component({\r\n\t\t  selector: \'app-");
            
            #line 25 "D:\Works\YashilSPL\CodeGeneratorGreen\CodeGeneratorGreen\Templates\Angular\CRUD\ListForm\AngularListForm.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(angularFriendlyName));
            
            #line default
            #line hidden
            this.Write("-list\',\r\n\t\t  templateUrl: \'./");
            
            #line 26 "D:\Works\YashilSPL\CodeGeneratorGreen\CodeGeneratorGreen\Templates\Angular\CRUD\ListForm\AngularListForm.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(angularFriendlyName));
            
            #line default
            #line hidden
            this.Write("-list.component.html\'\r\n\t\t})\r\n\t\texport class ");
            
            #line 28 "D:\Works\YashilSPL\CodeGeneratorGreen\CodeGeneratorGreen\Templates\Angular\CRUD\ListForm\AngularListForm.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(table.Name));
            
            #line default
            #line hidden
            this.Write("ListComponent {\r\n\t\t  selectedItemId: number;\r\n\t\t  columns: any[] = [];\r\n\t\t  entit" +
                    "yName = \'");
            
            #line 31 "D:\Works\YashilSPL\CodeGeneratorGreen\CodeGeneratorGreen\Templates\Angular\CRUD\ListForm\AngularListForm.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(firstCharacterLower));
            
            #line default
            #line hidden
            this.Write("\';\r\n\t\t  detailComponent =");
            
            #line 32 "D:\Works\YashilSPL\CodeGeneratorGreen\CodeGeneratorGreen\Templates\Angular\CRUD\ListForm\AngularListForm.tt"
if(table.GenerateTabForDescColumn){
            
            #line default
            #line hidden
            this.Write("  ");
            
            #line 32 "D:\Works\YashilSPL\CodeGeneratorGreen\CodeGeneratorGreen\Templates\Angular\CRUD\ListForm\AngularListForm.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(table.Name));
            
            #line default
            #line hidden
            this.Write("DetailTabBasedComponent; ");
            
            #line 32 "D:\Works\YashilSPL\CodeGeneratorGreen\CodeGeneratorGreen\Templates\Angular\CRUD\ListForm\AngularListForm.tt"
} else { 
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 32 "D:\Works\YashilSPL\CodeGeneratorGreen\CodeGeneratorGreen\Templates\Angular\CRUD\ListForm\AngularListForm.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(table.Name));
            
            #line default
            #line hidden
            this.Write("DetailComponent; ");
            
            #line 32 "D:\Works\YashilSPL\CodeGeneratorGreen\CodeGeneratorGreen\Templates\Angular\CRUD\ListForm\AngularListForm.tt"
}
            
            #line default
            #line hidden
            this.Write("\t\t  constructor() {\r\n\t\t\t");
            
            #line 34 "D:\Works\YashilSPL\CodeGeneratorGreen\CodeGeneratorGreen\Templates\Angular\CRUD\ListForm\AngularListForm.tt"

			// Iterate all columns

			
			foreach (var col in table.Columns.Where(x => !ApplicationInfo.Instance.skipedColumnInAngularList.Contains(x.Name)))
			{
				if(col.Name=="Code" || col.Name=="AccessLevelId")
				{
					continue;
				}
				var colCaption = col.Name.FirstCharacterToLower();

				// If we can't map it, skip it
				string colNamef;
				if (col.IsForeignKey)
					colNamef = colCaption.Replace("Id", "") + "Title";
				else
					colNamef = col.Name.FirstCharacterToLower();
				string propertyType = SqlToCsharpHelper.GetNetDataType(col.ColType);
				if((propertyType == "string" &&  col.MaxLength=="-1")){
							continue;
					}
				colCaption = string.IsNullOrEmpty(col.ColDesc) ? col.Name : col.ColDesc.Replace("*", "");
				
            
            #line default
            #line hidden
            this.Write("\t\t\t\tthis.columns.push({ \r\n\t\t\t\t\tcaption: \'");
            
            #line 59 "D:\Works\YashilSPL\CodeGeneratorGreen\CodeGeneratorGreen\Templates\Angular\CRUD\ListForm\AngularListForm.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(colCaption));
            
            #line default
            #line hidden
            this.Write("\',\r\n\t\t\t\t\tdataField: \'");
            
            #line 60 "D:\Works\YashilSPL\CodeGeneratorGreen\CodeGeneratorGreen\Templates\Angular\CRUD\ListForm\AngularListForm.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(colNamef));
            
            #line default
            #line hidden
            this.Write("\'\r\n\t\t\t\t\t});\r\n\t\t\t");
            
            #line 62 "D:\Works\YashilSPL\CodeGeneratorGreen\CodeGeneratorGreen\Templates\Angular\CRUD\ListForm\AngularListForm.tt"

			} 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\r\n\t\t\t\t}\r\n\t\t}\r\n");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public class AngularListFormBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}
