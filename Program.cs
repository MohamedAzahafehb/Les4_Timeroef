// See https://aka.ms/new-console-template for more information
using System.Timers;

Console.WriteLine("Hello, World!");

int keuze = 0;
System.Timers.Timer timer;
TimeSpan sluimerTijd;
Wekmethode wekMethode = delegate { };

do
{
    Console.WriteLine("1. tijd kan instellen waarop je wekker \"afloopt\"");
    Console.WriteLine("2. sluimertijd kan instellen nadat je wekker is afgelopen!");
    Console.WriteLine("3.stop alarm");
    Console.WriteLine("4. sluimerknop");
    Console.WriteLine("5. kies manier van wekken");
    Console.WriteLine("0. Sluit Af");

    keuze = Int32.Parse(Console.ReadLine());

    switch (keuze)
    {
        case 1:
            Console.WriteLine("stel de alarmtijd in: ");
            DateTime tijd = DateTime.Parse(Console.ReadLine());
            stelTijdIn(tijd);
            break;
        case 2:
            Console.WriteLine("stel de alarmtijd in: ");
            sluimerTijd = TimeSpan.Parse(Console.ReadLine());
            break;
        case 3:
            stopAlarm();
            break;
        case 4:
            //sluimer();
            break;
        case 5:
            Console.WriteLine("A. geluid");
            Console.WriteLine("B. boodschap");
            Console.WriteLine("C. knipperlicht");
            String choice = Console.ReadLine();
            switch (choice)
            {
                case "A":
                    wekMethode = new Wekmethode(maakGeluid);
                    wekMethode();
                    break;
                case "B":
                    wekMethode = new Wekmethode(toonBoodschap);
                    wekMethode();
                    break;
                case "C":
                    wekMethode = new Wekmethode(knipperLicht);
                    wekMethode();
                    break;
                default:
                    Console.WriteLine("Onjuiste keuze");
                    break;
            }
            break;
        case 0:

            break;
        default:
            Console.WriteLine("geen correcte invoer!");
            break;
    }
}
while (keuze != 0);

void stelTijdIn(DateTime alarmTijd)
{
    timer = new System.Timers.Timer(alarmTijd - DateTime.Now); //pakte steeds System.Threading.Timer
    timer.Elapsed += (sender, e) => wekMethode();
    timer.AutoReset = false;
    timer.Start();
    Console.WriteLine("Alarm gezet op: " + alarmTijd + ". Dat is over "+ (alarmTijd - DateTime.Now));
}
void stopAlarm()
{
    timer?.Stop();
}
void sluimer()
{
    stelTijdIn(DateTime.Now.Add(sluimerTijd));
}
void maakGeluid()
{
    Console.WriteLine("BEEP BEEP BEEP");
}
void toonBoodschap()
{
    Console.WriteLine("Tijd om op te staan!");
}
void knipperLicht()
{
    Console.WriteLine("FLITS FLITS FLITS");
}


delegate void Wekmethode();