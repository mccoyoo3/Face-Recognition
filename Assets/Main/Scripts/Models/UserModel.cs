using System;

[Serializable]
public class UserModel
{
    public string companyName;
    public string userName;
    public string password;
    public string email;
    public string firstName;
    public string lastName;
    public string displayName;
    public long phoneNumber;
    public string address;
    public int zipCode;
    public string country;
    public string timeZone;
    public float allowableRadius;
    public bool isStudent;

    public UserModel(string companyName, string userName, string password, string email, string firstName,
        string lastName, string displayName, long phoneNumber, string address, int zipCode, string country,
        string timeZone, float allowableRadius, bool isStudent)
    {
        this.companyName = companyName;
        this.userName = userName;
        this.password = password;
        this.email = email;
        this.firstName = firstName;
        this.lastName = lastName;
        this.displayName = displayName;
        this.phoneNumber = phoneNumber;
        this.address = address;
        this.zipCode = zipCode;
        this.country = country;
        this.timeZone = timeZone;
        this.allowableRadius = allowableRadius;
        this.isStudent = isStudent;
    }
}