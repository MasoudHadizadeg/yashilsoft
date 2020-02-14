using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using CodeGeneratorGreen.Classes;

namespace CodeGeneratorGreen.Models
{
    [XmlRoot(ElementName = "Column")]
    public class Column
    {
        [XmlAttribute(AttributeName = "name")] public string Name { get; set; }

        [XmlAttribute(AttributeName = "id")] public string Id { get; set; }

        [XmlAttribute(AttributeName = "isForeignKey")]
        public string IsForeignKeyStr { get; set; }

        public bool IsForeignKey => IsForeignKeyStr == "1";

        [XmlAttribute(AttributeName = "colType")]
        public string ColType { get; set; }

        [XmlAttribute(AttributeName = "colDesc")]
        public string ColDesc { get; set; }

        [XmlAttribute(AttributeName = "maxLength")]
        public string MaxLength { get; set; }

        [XmlAttribute(AttributeName = "scale")]
        public string Scale { get; set; }

        [XmlAttribute(AttributeName = "isNullable")]
        public string IsNullable { get; set; }

        public bool AllowNull => IsNullable == "1";

        [XmlAttribute(AttributeName = "isIdentity")]
        public string IsIdentity { get; set; }

        [XmlAttribute(AttributeName = "isComputed")]
        public string IsComputed { get; set; }

        [XmlAttribute(AttributeName = "isPrimaryKey")]
        public string IsPrimaryKey { get; set; }

        [XmlAttribute(AttributeName = "foreignKeyName")]
        public string ForeignKeyName { get; set; }

        [XmlAttribute(AttributeName = "constraintColumnName")]
        public string ConstraintColumnName { get; set; }

        [XmlAttribute(AttributeName = "referencedObject")]
        public string ReferencedObject { get; set; }


        [XmlAttribute(AttributeName = "referencedObjectTitleColumn")]
        public string ReferencedObjectTitleColumn { get; set; }

        [XmlAttribute(AttributeName = "referencedObjectIsLarge")]
        public string ReferencedObjectIsLargeStr { get; set; }

        public bool ReferencedObjectIsLarge => ReferencedObjectIsLargeStr == "1";


        [XmlAttribute(AttributeName = "referencedColumnName")]
        public string ReferencedColumnName { get; set; }

        [XmlAttribute(AttributeName = "referencedColumnTitle")]
        public string ReferencedColumnTitle { get; set; }
    }

    [XmlRoot(ElementName = "Table")]
    public class Table
    {
        [XmlElement(ElementName = "Column")] 
        public List<Column> Columns { get; set; }

        [XmlAttribute(AttributeName = "schema")]
        public string Schema { get; set; }

        [XmlAttribute(AttributeName = "name")] public string Name { get; set; }

        [XmlAttribute(AttributeName = "id")] public string Id { get; set; }

        [XmlAttribute(AttributeName = "tableDesc")]
        public string TableDesc { get; set; }

        public string TablePersianName => TableDesc ?? "";

        public bool IsApplicationBased => Columns.Any(x => x.Name == "ApplicationId");
    }

    [XmlRoot(ElementName = "Tables")]
    public class Tables
    {
        [XmlElement(ElementName = "Table")] public List<Table> TableListFull { get; set; }

        public List<Table> TableList
        {
            get { return TableListFull.Where(x => !ApplicationInfo.Instance.skipedTables.Contains(x.Name)).ToList(); }
        }
    }
}