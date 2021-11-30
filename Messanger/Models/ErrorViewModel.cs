using System;
using Microsoft.EntityFrameworkCore;

namespace Messanger.Models
{
	public class ErrorViewModel
	{
		public string RequestId { get; set; }

		public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
	}

	
	

}
