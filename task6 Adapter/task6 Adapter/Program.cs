using System;
namespace AdapterExample
{
    // Система яку будемо адаптовувати:
    // адаптувати слова старої пісні
    // під нову мелодію для нового плеєра
    class OldSong
    {
        public string SingOldSong()
        {
            return "lyrics";
        }
    }
    //інтерфейс для нової системи
    interface INewSongSystem
    {
        string SingNewSong();
    }
    //пісня під новий плеєр
    class NewSongSystem : INewSongSystem
    {
        public string SingNewSong()
        {
            return "new notes";
        }
    }
    //Адаптер виконує нову мелодію, але під стару лірику,
    //шляхом наслудівання прийнятного плеєру інтерфейсу
    class Adapter : INewSongSystem
    {
        // усередині стара лірика
        private readonly OldSong _adaptee;
        public Adapter(OldSong adaptee)
        {
            _adaptee = adaptee;
        }
        //нова мелодія
        public string SingNewSong()
        {
            return _adaptee.SingOldSong();
        }
    }
    
    // плеєр, який може грати лише нову музику
    class Mp3Player
    {
        public static void SingSong(INewSongSystem songSystem)
        {
            Console.WriteLine(songSystem.SingNewSong());
        }
    }

    public class AdapterDemo
    {
        static void Main()
        {
            var newSongSystem = new NewSongSystem();
            Mp3Player.SingSong(newSongSystem);

            var oldSong = new OldSong();
            var adapter = new Adapter(oldSong);

            Mp3Player.SingSong(adapter);

            Console.ReadKey();
        }
    }
}
