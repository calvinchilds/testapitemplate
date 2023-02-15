using System;
using System.Threading.Tasks;
using TestApi.Services;

namespace TestApi
{
    public class ProgramExecution
    {
        private readonly SongService _songService;

        public ProgramExecution(SongService songService)
        {
            _songService = songService;
        }
        
        public async Task Run(string[] args)
        {
            var formattedSongs = await _songService.GetFormattedSongs(args);
            Console.WriteLine(formattedSongs);
        }
    }
}
