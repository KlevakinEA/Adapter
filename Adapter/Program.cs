PCGame test = new Adapter(new ComputerGame("DOOM", PegiAgeRating.P18, 1, 2, 0, 0, 1, 0.1));
Console.WriteLine(test.getTitle());
Console.WriteLine(test.isTripleAGame());
Console.WriteLine(test.getPegiAllowedAge());
Console.WriteLine(test.getRequirements().getCpuGhz());


public class ComputerGame
{
    private string name;
    private PegiAgeRating pegiAgeRating;
    private double budgetInMillionsOfDollars;
    private int minimumGpuMemoryInMegabytes;
    private int diskSpaceNeededInGB;
    private int ramNeededInGb;
    private int coresNeeded;
    private double coreSpeedInGhz;

    public ComputerGame(string name,
                        PegiAgeRating pegiAgeRating,
                        double budgetInMillionsOfDollars,
                        int minimumGpuMemoryInMegabytes,
                        int diskSpaceNeededInGB,
                        int ramNeededInGb,
                        int coresNeeded,
                        double coreSpeedInGhz)
    {
        this.name = name;
        this.pegiAgeRating = pegiAgeRating;
        this.budgetInMillionsOfDollars = budgetInMillionsOfDollars;
        this.minimumGpuMemoryInMegabytes = minimumGpuMemoryInMegabytes;
        this.diskSpaceNeededInGB = diskSpaceNeededInGB;
        this.ramNeededInGb = ramNeededInGb;
        this.coresNeeded = coresNeeded;
        this.coreSpeedInGhz = coreSpeedInGhz;
    }

    public string getName()
    {
        return name;
    }

    public PegiAgeRating getPegiAgeRating()
    {
        return pegiAgeRating;
    }

    public double getBudgetInMillionsOfDollars()
    {
        return budgetInMillionsOfDollars;
    }

    public int getMinimumGpuMemoryInMegabytes()
    {
        return minimumGpuMemoryInMegabytes;
    }

    public int getDiskSpaceNeededInGB()
    {
        return diskSpaceNeededInGB;
    }

    public int getRamNeededInGb()
    {
        return ramNeededInGb;
    }

    public int getCoresNeeded()
    {
        return coresNeeded;
    }

    public double getCoreSpeedInGhz()
    {
        return coreSpeedInGhz;
    }
}

public enum PegiAgeRating
{
    P3, P7, P12, P16, P18
}

public class Requirements
{
    private int gpuGb;
    private int HDDGb;
    private int RAMGb;
    private double cpuGhz;
    private int coresNum;

    public Requirements(int gpuGb,
                        int HDDGb,
                        int RAMGb,
                        double cpuGhz,
                        int coresNum)
    {
        this.gpuGb = gpuGb;
        this.HDDGb = HDDGb;
        this.RAMGb = RAMGb;
        this.cpuGhz = cpuGhz;
        this.coresNum = coresNum;
    }

    public int getGpuGb()
    {
        return gpuGb;
    }

    public int getHDDGb()
    {
        return HDDGb;
    }

    public int getRAMGb()
    {
        return RAMGb;
    }

    public double getCpuGhz()
    {
        return cpuGhz;
    }

    public int getCoresNum()
    {
        return coresNum;
    }
}

public interface PCGame
{
    string getTitle();
    int getPegiAllowedAge();
    bool isTripleAGame();
    Requirements getRequirements();
}

class Adapter: PCGame
{
    private ComputerGame ComputerGame;
    public string getTitle() { return ComputerGame.getName(); }
    public int getPegiAllowedAge() 
    {
        if (ComputerGame.getPegiAgeRating() == PegiAgeRating.P3) { return 3; }
        else if (ComputerGame.getPegiAgeRating() == PegiAgeRating.P7) { return 7; }
        else if (ComputerGame.getPegiAgeRating() == PegiAgeRating.P12) { return 12; }
        else if (ComputerGame.getPegiAgeRating() == PegiAgeRating.P16) { return 16; }
        else { return 18; }
    }
    public bool isTripleAGame() { return (ComputerGame.getBudgetInMillionsOfDollars() > 50); }
    public Requirements getRequirements() { return new Requirements(ComputerGame.getMinimumGpuMemoryInMegabytes(), ComputerGame.getDiskSpaceNeededInGB(), ComputerGame.getRamNeededInGb(), ComputerGame.getCoreSpeedInGhz(), ComputerGame.getCoresNeeded()); }
    public Adapter(ComputerGame computerGame) { ComputerGame = computerGame; }
}