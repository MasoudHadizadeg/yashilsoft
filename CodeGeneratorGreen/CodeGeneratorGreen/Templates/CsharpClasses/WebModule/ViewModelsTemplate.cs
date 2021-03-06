﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 16.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace CodeGeneratorGreen.Templates.CsharpClasses.WebModule
{
    using Classes;
    using CodeGeneratorGreen.Models;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "D:\Works\YashilSPL\CodeGeneratorGreen\CodeGeneratorGreen\Templates\CsharpClasses\WebModule\ViewModelsTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class ViewModelsTemplate : ViewModelsTemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("\t\t\t");
            
            #line 8 "D:\Works\YashilSPL\CodeGeneratorGreen\CodeGeneratorGreen\Templates\CsharpClasses\WebModule\ViewModelsTemplate.tt"

			var table = SqlToCsharpHelper.table;
			
            
            #line default
            #line hidden
            this.Write("using System;\r\nusing System.ComponentModel.DataAnnotations;\r\nusing Yashil.Common." +
                    "Core.Interfaces;\r\nnamespace ");
            
            #line 14 "D:\Works\YashilSPL\CodeGeneratorGreen\CodeGeneratorGreen\Templates\CsharpClasses\WebModule\ViewModelsTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ApplicationInfo.Instance.ViewModelNamespace));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n\r\n   public class ");
            
            #line 17 "D:\Works\YashilSPL\CodeGeneratorGreen\CodeGeneratorGreen\Templates\CsharpClasses\WebModule\ViewModelsTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(table.Name));
            
            #line default
            #line hidden
            this.Write("ListViewModel:IBaseViewModel\r\n    {\r\n\t\tpublic int ViewModelId\r\n\t        {\r\n\t     " +
                    "       get => Id;\r\n\t            set => Id = value;\r\n\t        }\r\n\t\tpublic int? Pa" +
                    "rentId { get; set; }\r\n");
            
            #line 25 "D:\Works\YashilSPL\CodeGeneratorGreen\CodeGeneratorGreen\Templates\CsharpClasses\WebModule\ViewModelsTemplate.tt"

			// Keep count so we don't whitespace the last property/column
			int i = 0;
			// Iterate all columns
			foreach (Column col in table.Columns.Where(x => !ApplicationInfo.Instance.skipedColumns.Contains(x.Name)))
			{
				i++;
				string propertyType = SqlToCsharpHelper.GetNetDataType(col.ColType);
				// If we can't map it, skip it
				if (string.IsNullOrWhiteSpace(propertyType) || propertyType == "byte[]" || (propertyType == "string" &&  col.MaxLength=="-1"))
				{
					// Skip
					continue;
				}

				// Handle nullable columns by making the type nullable
				if (col.AllowNull && (propertyType != "string" && propertyType != "byte[]"))
				{
					propertyType += "?";
				}
				string colNamef;
				if (col.IsForeignKey)
					{
						colNamef = col.Name.Replace("Id", "") + "Title";
						propertyType ="string";
					}
				else
					colNamef = col.Name;
				
				if((propertyType == "string" &&  col.MaxLength=="-1")){
							continue;
					}
				
            
            #line default
            #line hidden
            this.Write("        public ");
            
            #line 58 "D:\Works\YashilSPL\CodeGeneratorGreen\CodeGeneratorGreen\Templates\CsharpClasses\WebModule\ViewModelsTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(propertyType));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 58 "D:\Works\YashilSPL\CodeGeneratorGreen\CodeGeneratorGreen\Templates\CsharpClasses\WebModule\ViewModelsTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(colNamef));
            
            #line default
            #line hidden
            this.Write(" { get; set; }\r\n\r\n");
            
            #line 60 "D:\Works\YashilSPL\CodeGeneratorGreen\CodeGeneratorGreen\Templates\CsharpClasses\WebModule\ViewModelsTemplate.tt"

			}

            
            #line default
            #line hidden
            this.Write("    }\r\n\r\n\r\n\t    public class ");
            
            #line 66 "D:\Works\YashilSPL\CodeGeneratorGreen\CodeGeneratorGreen\Templates\CsharpClasses\WebModule\ViewModelsTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(table.Name));
            
            #line default
            #line hidden
            this.Write("EditModel:IBaseViewModel\r\n        {\r\n\t        public int ViewModelId\r\n\t          " +
                    "  {\r\n\t                get => Id;\r\n\t                set => Id = value;\r\n\t        " +
                    "    }\r\n");
            
            #line 73 "D:\Works\YashilSPL\CodeGeneratorGreen\CodeGeneratorGreen\Templates\CsharpClasses\WebModule\ViewModelsTemplate.tt"

			// Keep count so we don't whitespace the last property/column
			var columnCount = table.Columns.Count;
			i = 0;
			// Iterate all columns
			foreach (Column col in table.Columns.Where(x => !ApplicationInfo.Instance.skipedColumns.Contains(x.Name)))
			{
				i++;
				string propertyType = SqlToCsharpHelper.GetNetDataType(col.ColType);
				// If we can't map it, skip it
				
				if (string.IsNullOrWhiteSpace(propertyType) || (propertyType == "string" &&  col.MaxLength=="-1" && table.GenerateTabForDescColumn))
				{
					// Skip
					continue;
				}
				// Handle nullable columns by making the type nullable
				if (col.AllowNull && (propertyType != "string" && propertyType != "byte[]"))
				{
					propertyType += "?";
				}

				if (propertyType == "int" && col.IsPrimaryKey != "1")
				{
					
            
            #line default
            #line hidden
            this.Write("\t\t\t\t[Range(0,int.MaxValue)]");
            
            #line 98 "D:\Works\YashilSPL\CodeGeneratorGreen\CodeGeneratorGreen\Templates\CsharpClasses\WebModule\ViewModelsTemplate.tt"
}
				if (propertyType == "string" && col.MaxLength!="-1"){
            
            #line default
            #line hidden
            this.Write("\t\t\t\t[StringLength(");
            
            #line 100 "D:\Works\YashilSPL\CodeGeneratorGreen\CodeGeneratorGreen\Templates\CsharpClasses\WebModule\ViewModelsTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.MaxLength));
            
            #line default
            #line hidden
            this.Write(")]");
            
            #line 100 "D:\Works\YashilSPL\CodeGeneratorGreen\CodeGeneratorGreen\Templates\CsharpClasses\WebModule\ViewModelsTemplate.tt"
}
				if (!col.AllowNull && col.IsPrimaryKey != "1" && propertyType!="bool"){
            
            #line default
            #line hidden
            this.Write(" \r\n\t\t\t\t[Required]");
            
            #line 102 "D:\Works\YashilSPL\CodeGeneratorGreen\CodeGeneratorGreen\Templates\CsharpClasses\WebModule\ViewModelsTemplate.tt"
}
            
            #line default
            #line hidden
            this.Write("\t\t\t\tpublic ");
            
            #line 103 "D:\Works\YashilSPL\CodeGeneratorGreen\CodeGeneratorGreen\Templates\CsharpClasses\WebModule\ViewModelsTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(propertyType));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 103 "D:\Works\YashilSPL\CodeGeneratorGreen\CodeGeneratorGreen\Templates\CsharpClasses\WebModule\ViewModelsTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.Name));
            
            #line default
            #line hidden
            this.Write(" { get; set; }\t\t\r\n");
            
            #line 104 "D:\Works\YashilSPL\CodeGeneratorGreen\CodeGeneratorGreen\Templates\CsharpClasses\WebModule\ViewModelsTemplate.tt"
}
            
            #line default
            #line hidden
            this.Write("}\r\n\r\n  \r\n\r\n\r\n\r\npublic class ");
            
            #line 111 "D:\Works\YashilSPL\CodeGeneratorGreen\CodeGeneratorGreen\Templates\CsharpClasses\WebModule\ViewModelsTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(table.Name));
            
            #line default
            #line hidden
            this.Write("SimpleViewModel:IBaseViewModel\r\n        {\r\n\t        public int ViewModelId\r\n\t    " +
                    "        {\r\n\t                get => Id;\r\n\t                set => Id = value;\r\n\t  " +
                    "          }\r\n");
            
            #line 118 "D:\Works\YashilSPL\CodeGeneratorGreen\CodeGeneratorGreen\Templates\CsharpClasses\WebModule\ViewModelsTemplate.tt"

			// Keep count so we don't whitespace the last property/column
			columnCount = table.Columns.Count;
			i = 0;
			// Iterate all columns
			bool hasTitleColumn = false;
			foreach (Column col in table.Columns.Where(x =>
				ApplicationInfo.Instance.SimpleViewModelColumns.Contains(x.Name)))
			{
				i++;
				string propertyType = SqlToCsharpHelper.GetNetDataType(col.ColType);
				if (col.Name == "Title")
				{
					hasTitleColumn = true;
				}

				
            
            #line default
            #line hidden
            this.Write("        public ");
            
            #line 135 "D:\Works\YashilSPL\CodeGeneratorGreen\CodeGeneratorGreen\Templates\CsharpClasses\WebModule\ViewModelsTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(propertyType));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 135 "D:\Works\YashilSPL\CodeGeneratorGreen\CodeGeneratorGreen\Templates\CsharpClasses\WebModule\ViewModelsTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.Name));
            
            #line default
            #line hidden
            this.Write(" { get; set; }\r\n\r\n\t\t\t");
            
            #line 137 "D:\Works\YashilSPL\CodeGeneratorGreen\CodeGeneratorGreen\Templates\CsharpClasses\WebModule\ViewModelsTemplate.tt"

			}
			
			if (!hasTitleColumn)
			{
				
            
            #line default
            #line hidden
            this.Write("\t\t\t\tpublic string Title { get; set; }\r\n\t\t\t");
            
            #line 144 "D:\Works\YashilSPL\CodeGeneratorGreen\CodeGeneratorGreen\Templates\CsharpClasses\WebModule\ViewModelsTemplate.tt"

			} 
            
            #line default
            #line hidden
            this.Write("    }\r\n\r\n}      \r\n");
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
    public class ViewModelsTemplateBase
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
