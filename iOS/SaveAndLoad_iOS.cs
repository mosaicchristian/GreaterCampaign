using System;
using Xamarin.Forms;
using System.IO;
using System.Threading.Tasks;
using Foundation;
using System.Linq;
using GreaterCampaign.Services;
using GreaterCampaign.iOS;

[assembly: Dependency(typeof(SaveAndLoad_iOS))]

namespace GreaterCampaign.iOS
{
    public class SaveAndLoad_iOS : ISaveAndLoad
    {
		public static string DocumentsPath
    	{
    		get
    		{
    			var documentsDirUrl = NSFileManager.DefaultManager.GetUrls(NSSearchPathDirectory.DocumentDirectory, NSSearchPathDomain.User).Last();
    			return documentsDirUrl.Path;
    		}
    	}

    	#region ISaveAndLoad implementation

    	public async Task SaveTextAsync(string filename, string text)
    	{
    		string path = CreatePathToFile(filename);
    		using (StreamWriter sw = File.CreateText(path))
    			await sw.WriteAsync(text);
    	}

    	public async Task<string> LoadTextAsync(string filename)
    	{
    		string path = CreatePathToFile(filename);
    		using (StreamReader sr = File.OpenText(path))
    			return await sr.ReadToEndAsync();
    	}

		public TimeSpan GetTime(string filename)
		{
			var path = CreatePathToFile(filename);
			StreamReader sr = File.OpenText(path);
			TimeSpan reminderTime = new TimeSpan(0, 0, 0);

            if (!sr.EndOfStream && sr.ReadLine().Contains("Reminder"))
			{
				// Read the time and pass it back out
				reminderTime = TimeSpan.Parse(sr.ReadLine());
			}
            sr.Dispose();
			return reminderTime;
		}

    	public bool FileExists(string filename)
    	{
    		return File.Exists(CreatePathToFile(filename));
    	}

    	#endregion

    	static string CreatePathToFile(string fileName)
    	{
    		return Path.Combine(DocumentsPath, fileName);
    	}
    }
}
