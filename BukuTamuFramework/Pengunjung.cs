using System;
using System.Collections.Generic;

namespace BukuTamuFramework
{
    public class Pengunjung
    {
        public string id { get; set; }
        public DateTime Tanggal { get; set; }
        public string Nama { get; set; }
        public string Email { get; set; }
        public string Alamat { get; set; }
        public string Kelamin { get; set; }
        public string NomorHP { get; set; }
        public string Pekerjaan { get; set; }
        public string Keperluan { get; set; }
        public string Keterangan { get; set; }
        public string FotoPath { get; set; }
    }

    public class RootObject
    {
        public List<Pengunjung> PengunjungList { get; set; }
    }
}
