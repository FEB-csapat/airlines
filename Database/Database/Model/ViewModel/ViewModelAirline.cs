using Database;

namespace Database.Database.Model.ViewModel
{
    public class ViewModelAirline
    {
        public string Name { get; set; }

        public ViewModelAirline()
        {

        }

        public ViewModelAirline(string name)
        {
            Name = name;
        }
    }
}
