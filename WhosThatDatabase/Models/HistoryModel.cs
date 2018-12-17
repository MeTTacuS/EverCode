using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhosThatDatabase.Models
{
	public class HistoryModel
	{
        public string Username { get; set; }
        public DateTime Date { get; set; }
        public int Points { get; set; }
		public int ID { get; set; }
    }
}