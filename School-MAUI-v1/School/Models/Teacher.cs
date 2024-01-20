namespace School;
public class Teacher : Person
{
    private int salary;
    public Teacher(string firstname, string lastname, int salary) : base(firstname, lastname) {
        this.salary = salary;
    }

    public override string ToString()
    {
        return String.Format("{0} ({1})", DisplayName(), salary);
    }

    public int Salary {
        get {
            return salary;
        }
    }
}
