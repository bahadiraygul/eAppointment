
using Ardalis.SmartEnum;

namespace eAppointmentServer.Domain.Enums;

public sealed class DepartmentEnum : SmartEnum<DepartmentEnum>
{
    public static readonly DepartmentEnum Acil = new("Acil", 1);
    public static readonly DepartmentEnum Kardiyoloji = new("Kardiyoloji", 2);
    public static readonly DepartmentEnum Ortopedi = new("Ortopedi", 3);
    public static readonly DepartmentEnum Dahiliye = new("Dahiliye", 4);
    public static readonly DepartmentEnum Goz = new("Göz", 5);
    public static readonly DepartmentEnum KulakBurunBogaz = new("Kulak Burun Boğaz", 6);
    public static readonly DepartmentEnum Cocuk = new("Çocuk", 7);
    public static readonly DepartmentEnum Nefroloji = new("Nefroloji", 8);
    public static readonly DepartmentEnum Endokrin = new("Endokrin", 9);
    public static readonly DepartmentEnum Psikiyatri = new("Psikiyatri", 10);
    public static readonly DepartmentEnum Dermatoloji = new("Dermatoloji", 11);
    public static readonly DepartmentEnum Onkoloji = new("Onkoloji", 12);
    public static readonly DepartmentEnum FizikTedavi = new("Fizik Tedavi", 13);
    public static readonly DepartmentEnum KadınDoğum = new("Kadın Doğum", 14);
    public static readonly DepartmentEnum BeyinVeSinirCerrahisi = new("Beyin ve Sinir Cerrahisi", 15);

    public DepartmentEnum(string name, int value) : base(name, value) { }
}
