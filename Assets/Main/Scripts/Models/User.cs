
public class User 
{
    public string _companyName;
    public string _userName;
    public string _password;
    public string _email;
    public string _firstName;
    public string _lastName;
    public string _displayName;
    public int _phoneNumber;
    public string _address;
    public int _zipCode;
    public string _country;
    public string _timeZone;
    public float _allowableRadius;

    public User(string companyName, string userName, string password, string email, string firstName, string lastName, string displayName, int phoneNumber,
        string address, int zipCode, string country, string timeZone, float allowableRadius)
    {
        this._companyName = companyName;
        this._userName = userName; 
        this._password = password;
        this._email = email;
        this._firstName = firstName;
        this._lastName = lastName;
        this._displayName = displayName;
        this._phoneNumber = phoneNumber;
        this._address = address;
        this._zipCode = zipCode;
        this._country = country;
        this._timeZone = timeZone;
        this._allowableRadius = allowableRadius;
    }
}
