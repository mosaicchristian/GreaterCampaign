using System;
using Xamarin.Forms;
using GreaterCampaign.Droid;
using System.IO;
using System.Threading.Tasks;
using GreaterCampaign.Services;

[assembly: Dependency(typeof(SaveAndLoad_Android))]

namespace GreaterCampaign.Droid
{
    public class SaveAndLoad_Android : ISaveAndLoad
	{
		#region ISaveAndLoad implementation

		public async Task SaveTextAsync(string filename, string text)
		{
			var path = CreatePathToFile(filename);
			using (StreamWriter sw = File.CreateText(path)) // creates a error
				await sw.WriteAsync(text);
		}

		public async Task<string> LoadTextAsync(string filename)
		{
			var path = CreatePathToFile(filename);
			using (StreamReader sr = File.OpenText(path))
				return await sr.ReadToEndAsync();
		}

        public TimeSpan GetTime(string filename)
        {
            var path = CreatePathToFile(filename);
            StreamReader sr = File.OpenText(path);
            TimeSpan reminderTime = new TimeSpan(0, 0, 0);

            if (!sr.EndOfStream && sr.ReadLine().Contains("Reminder") )
            {
                // Read the time and pass it back out
                reminderTime = TimeSpan.Parse(sr.ReadLine());
            }
            sr.Dispose();
            return reminderTime;
        }

		public bool FileExists(string filename)
		{
            //var path = CreatePathToFile(filename);
            //bool result = File.Exists(CreatePathToFile(filename));
            //return result;
			return File.Exists(CreatePathToFile(filename));
		}

		#endregion

		string CreatePathToFile(string filename)
		{
			var docsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			return Path.Combine(docsPath, filename);
		}
	}
}
