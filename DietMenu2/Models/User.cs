
namespace DietMenu.Entities
{
    using System.Text.RegularExpressions;

    using DietMenu.Modules;

    public class User
    {
        private const double MinWeight = 0;

        private const double MaxWeight = 351;

        private const double MinHeight = 0;

        private const double MaxHeight = 351;

        private const int MinAge = 0;

        private const int MaxAge = 121;

        private string _login;

        private string _password;

        private string _name;

        private string _surname;

        private double? _userWeight;

        private double? _userHeight;

        private int? _userAge;

        private int? _genderId;

        private int? _userTypeId;

        private Regex nameRegex = new Regex("^[A-Za-zА-Яа-я ]{0,25}$");

        private Regex loginRegex = new Regex("^[A-Za-zА-Яа-я0-9 ]{0,25}$");

        public User()
        {
        }

        public User(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public int Id { get; set; }

        public string Login
        {
            get => _login;

            set
            {
                if (value == null || loginRegex.IsMatch(value))
                {
                    _login = value;
                }
            }
        }

        public string Hash { get; set; }

        public string Password
        {
            get => _password;

            set
            {
                if (value == null || value.Length < 21)
                {
                    _password = value;
                }
            }
        }

        public string Name
        {
            get => _name;

            set
            {
                if (value == null || nameRegex.IsMatch(value))
                {
                    _name = value;
                }
            }
        }

        public string Surname
        {
            get => _surname;

            set
            {
                if (value == null || nameRegex.IsMatch(value))
                {
                    _surname = value;
                }
            }
        }

        public string Weight
        {
            get
            {
                switch (_userWeight)
                {
                    case MinWeight:
                        {
                            return string.Empty;
                        }

                    case null:
                        {
                            return null;
                        }

                    default:
                        {
                            return _userWeight + " кг";
                        }
                }
            }

            set
            {
                if (value == null)
                {
                    _userWeight = null;
                }
                else
                {
                    value = value.Replace(" кг", string.Empty);

                    if (string.IsNullOrWhiteSpace(value))
                    {
                        _userWeight = MinWeight;
                    }
                    else
                    {
                        if (double.TryParse(value, out double weight))
                        {
                            if (weight > MinWeight && weight < MaxWeight)
                            {
                                _userWeight = weight;
                            }
                        }
                    }
                }
            }
        }

        public string Height
        {
            get
            {
                switch (_userHeight)
                {
                    case MinHeight:
                        {
                            return string.Empty;
                        }

                    case null:
                        {
                            return null;
                        }

                    default:
                        {
                            return _userHeight + " см";
                        }
                }
            }

            set
            {
                if (value == null)
                {
                    _userHeight = null;
                }
                else
                {
                    value = value.Replace(" см", string.Empty);

                    if (string.IsNullOrWhiteSpace(value))
                    {
                        _userHeight = MinHeight;
                    }
                    else
                    {
                        if (double.TryParse(value, out double height))
                        {
                            if (height > MinHeight && height < MaxHeight)
                            {
                                _userHeight = height;
                            }
                        }
                    }
                }
            }
        }

        public string Age
        {
            get
            {
                switch (_userAge)
                {
                    case MinAge:
                        {
                            return string.Empty;
                        }

                    case null:
                        {
                            return null;
                        }

                    default:
                        {
                            switch (_userAge % 10)
                            {
                                case 1:
                                    {
                                        return _userAge + " год";
                                    }

                                case 2:
                                case 3:
                                case 4:
                                    {
                                        return _userAge + " года";
                                    }

                                default:
                                    {
                                        return _userAge + " лет";
                                    }
                            }
                        }
                }
            }

            set
            {
                if (value == null)
                {
                    _userAge = null;
                }
                else
                {
                    foreach (string postfix in new[] { " года", " год", " лет" })
                    {
                        value = value.Replace(postfix, string.Empty);
                    }

                    if (string.IsNullOrWhiteSpace(value))
                    {
                        _userAge = MinAge;
                    }
                    else
                    {
                        if (int.TryParse(value, out int age))
                        {
                            if (age > MinAge && age < MaxAge)
                            {
                                _userAge = age;
                            }
                        }
                    }
                }
            }
        }

        public string GenderId
        {
            get
            {
                switch (_genderId)
                {
                    case null:
                        {
                            return null;
                        }

                    default:
                        {
                            return Data.GenderList.Find(x => x.GenderId == _genderId)?.GenderName;
                        }
                }
            }

            set
            {
                if (value == null)
                {
                    _genderId = null;
                }
                else
                {
                    int? result;
                    if (int.TryParse(value, out int id))
                    {
                        result = Data.GenderList.Find(x => x.GenderId == id)?.GenderId;
                    }
                    else
                    {
                        result = Data.GenderList.Find(x => x.GenderName == value)?.GenderId;
                    }

                    if (result != null)
                    {
                        _genderId = result;
                    }
                }
            }
        }

        public double GetUnformattedWeight => (double)_userWeight;

        public double GetUnformattedHeight => (double)_userHeight;

        public int GetUnformattedAge => (int)_userAge;

        public int GetUnformattedGenderId => (int)_genderId;

        public string FullName => $"{Name} {Surname}";

        public int TypeId { get; set; }

        public int EntityId { get; set; }
    }
}
