namespace School;
public class Appreciation : Evaluation
{
    private string appreciation;

    public Appreciation(Activity activity, string appreciation) : base(activity) {
        SetAppreciation(appreciation);
    }

    public Appreciation(Activity activity) : base(activity) {
        SetAppreciation("Not Set");
    }

    public void SetAppreciation(string appreciation) {
        this.appreciation = appreciation;
    }
    public string GetAppreciation() {
        return this.appreciation;
    }

    public override int Note()
    {
        switch(appreciation) {
            case "X":
                return 20;
            case "TB":
                return 16;
            case "B":
                return 12;
            case "C":
                return 8;
            case "N":
                return 4;
            default:
                return 0;
        }
    }
}
