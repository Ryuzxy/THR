using System;

public class Karyawan
{
    private string nama;
    private string id;
    private double gajiPokok;

    public string Nama
    {
        get { return nama; }
        set { nama = value; }
    }

    public string ID
    {
        get { return id; }
        set { id = value; }
    }

    public double GajiPokok
    {
        get { return gajiPokok; }
        set { gajiPokok = value; }
    }

    public virtual double HitungGaji()
    {
        return gajiPokok;
    }
}

public class KaryawanTetap : Karyawan
{
    private const double BonusTetap = 500000;

    public override double HitungGaji()
    {
        return GajiPokok + BonusTetap;
    }
}

public class KaryawanKontrak : Karyawan
{
    private const double PotonganKontrak = 200000;

    public override double HitungGaji()
    {
        return GajiPokok - PotonganKontrak;
    }
}

public class KaryawanMagang : Karyawan
{
    public override double HitungGaji()
    {
        return GajiPokok;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Masukkan jenis karyawan (Tetap/Kontrak/Magang): ");
        string jenisKaryawan = Console.ReadLine();

        Console.WriteLine("Masukkan nama karyawan: ");
        string nama = Console.ReadLine();

        Console.WriteLine("Masukkan ID karyawan: ");
        string id = Console.ReadLine();

        Console.WriteLine("Masukkan gaji pokok karyawan: ");
        double gajiPokok = Convert.ToDouble(Console.ReadLine());

        Karyawan karyawan;

        switch (jenisKaryawan.ToLower())
        {
            case "tetap":
                karyawan = new KaryawanTetap();
                break;
            case "kontrak":
                karyawan = new KaryawanKontrak();
                break;
            case "magang":
                karyawan = new KaryawanMagang();
                break;
            default:
                Console.WriteLine("Jenis karyawan tidak valid.");
                return;
        }

        karyawan.Nama = nama;
        karyawan.ID = id;
        karyawan.GajiPokok = gajiPokok;

        double gajiAkhir = karyawan.HitungGaji();
        Console.WriteLine($"Gaji akhir karyawan {karyawan.Nama} (ID: {karyawan.ID}) adalah: {gajiAkhir}");
    }
}
