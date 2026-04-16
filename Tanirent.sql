
CREATE DATABASE DBsewatani;
GO

-- 2. Tabel Admin
CREATE TABLE Admin (
    id_admin INT PRIMARY KEY IDENTITY(1,1),
    username VARCHAR(50) NOT NULL,
    password_hash VARCHAR(255) NOT NULL,
    nama_admin VARCHAR(100)
);

-- 3. Tabel Kategori
CREATE TABLE Kategori (
    id_kat INT PRIMARY KEY IDENTITY(1,1),
    nama_kategori VARCHAR(50) NOT NULL
);

-- 4. Tabel Alat_Mesin
CREATE TABLE Alat_Mesin (
    id_alat INT PRIMARY KEY IDENTITY(1,1),
    id_kat INT NOT NULL,
    nama_alat VARCHAR(100) NOT NULL,
    merk VARCHAR(50),
    tipe VARCHAR(50),
    harga_sewa DECIMAL(18,2),
    status_kondisi VARCHAR(50),
    status_ketersediaan VARCHAR(20) DEFAULT 'Tersedia',
    CONSTRAINT FK_Alat_Kategori FOREIGN KEY (id_kat) REFERENCES Kategori(id_kat)
);

-- 5. Tabel Penyewa
CREATE TABLE Penyewa (
    id_penyewa INT PRIMARY KEY IDENTITY(1,1),
    nama_petani VARCHAR(100) NOT NULL,
    no_hp VARCHAR(15),
    alamat TEXT
);

-- 6. Tabel Transaksi (Tanpa Lokasi Lahan)
CREATE TABLE Transaksi (
    id_transaksi INT PRIMARY KEY IDENTITY(1,1),
    id_alat INT NOT NULL,
    id_penyewa INT NOT NULL,
    id_admin INT NOT NULL,
    tgl_sewa DATETIME NOT NULL,
    tgl_kembali DATETIME NOT NULL,
    total_bayar DECIMAL(18,2),
    CONSTRAINT FK_Transaksi_Alat FOREIGN KEY (id_alat) REFERENCES Alat_Mesin(id_alat),
    CONSTRAINT FK_Transaksi_Penyewa FOREIGN KEY (id_penyewa) REFERENCES Penyewa(id_penyewa),
    CONSTRAINT FK_Transaksi_Admin FOREIGN KEY (id_admin) REFERENCES Admin(id_admin)
);

