namespace YashilReport.Core
{
    public class CommandJson
    {
        public string Command { get; set; }

        /// <summary>
        /// For Security Save Only Connection Name in This Field
        /// And U Can Find Connection String From Db By The Name Of Connection
        /// </summary>
        public string ConnectionString { get; set; }

        public string Database { get; set; }

        public string Event { get; set; }

        public bool PreventDefault { get; set; }

        public double Rnd { get; set; }

        public string QueryString { get; set; }
        public string Connection { get; set; }

        public string DataSource { get; set; }
    }
}