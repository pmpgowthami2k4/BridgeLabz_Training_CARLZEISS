using System;

namespace FacadePatternExample
{
    // Subsystem 1
    public class TV
    {
        public void On()
        {
            Console.WriteLine("TV is ON");
        }

        public void Off()
        {
            Console.WriteLine("TV is OFF");
        }
    }

    // Subsystem 2
    public class SoundSystem
    {
        public void On()
        {
            Console.WriteLine("Sound System is ON");
        }

        public void SetVolume(int level)
        {
            Console.WriteLine($"Volume set to {level}");
        }
    }

    // Subsystem 3
    public class Lights
    {
        public void Dim()
        {
            Console.WriteLine("Lights are dimmed");
        }
    }

    // Subsystem 4
    public class DVDPlayer
    {
        public void Play(string movie)
        {
            Console.WriteLine($"Playing movie: {movie}");
        }
    }

    // Facade
    public class HomeTheaterFacade
    {
        private TV _tv;
        private SoundSystem _sound;
        private Lights _lights;
        private DVDPlayer _dvd;

        public HomeTheaterFacade(TV tv, SoundSystem sound, Lights lights, DVDPlayer dvd)
        {
            _tv = tv;
            _sound = sound;
            _lights = lights;
            _dvd = dvd;
        }

        public void WatchMovie(string movie)
        {
            Console.WriteLine("Starting movie night...\n");

            _lights.Dim();
            _tv.On();
            _sound.On();
            _sound.SetVolume(10);
            _dvd.Play(movie);
        }
    }

    // Client
    class facade
    {
        static void Main(string[] args)
        {
            TV tv = new TV();
            SoundSystem sound = new SoundSystem();
            Lights lights = new Lights();
            DVDPlayer dvd = new DVDPlayer();

            HomeTheaterFacade theater = new HomeTheaterFacade(tv, sound, lights, dvd);

            theater.WatchMovie("Interstellar");

            Console.ReadLine();
        }
    }
}