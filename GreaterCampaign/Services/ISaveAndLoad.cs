using System;
using System.Threading.Tasks;

namespace GreaterCampaign.Services
{
    public interface ISaveAndLoad
    {
		Task SaveTextAsync(string filename, string text);
		Task<string> LoadTextAsync(string filename);
        TimeSpan GetTime(string filename);
		bool FileExists(string filename);
    }
}
