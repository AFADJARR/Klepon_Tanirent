
CREATE DATABASE DBsewatani;
GO

-- 2. Tabel Admin
CREATE TABLE Admin (
    id_admin INT PRIMARY KEY IDENTITY(1,1),
    username VARCHAR(50) NOT NULL,
    password_hash VARCHAR(255) NOT NULL,
    nama_admin VARCHAR(100)
);


select * from Admin; 

-- 3. Tabel Kategori
CREATE TABLE Kategori (
    id_kat INT PRIMARY KEY IDENTITY(1,1),
    nama_kategori VARCHAR(50) NOT NULL
);

-- 4. Tabel Alat_Mesinx`
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

select * from Alat_Mesin;

SELECT * FROM Alat_Mesin
DELETE FROM Alat_Mesin WHERE Merk = 'DJI'
ALTER TABLE Alat_Mesin
ADD CONSTRAINT CHK_HargaSewa CHECK (harga_sewa > 0);

ALTER TABLE Alat_Mesin
ADD CONSTRAINT CK_Nama_Alat CHECK (nama_alat NOT LIKE '%[0-9]%');

-- 5. Tabel Penyewa
CREATE TABLE Penyewa (
    id_penyewa INT PRIMARY KEY IDENTITY(1,1),
    nama_petani VARCHAR(100) NOT NULL,
    no_hp VARCHAR(15),
    alamat TEXT
);

ALTER TABLE Penyewa
ADD CONSTRAINT CK_Nama_Petani CHECK (nama_petani NOT LIKE '%[0-9]%');

ALTER TABLE Penyewa
ADD CONSTRAINT CK_NoHP CHECK (no_hp NOT LIKE '%[^0-9]%');

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
ALTER TABLE Transaksi ALTER COLUMN id_admin INT NULL;

ALTER TABLE Transaksi
ADD CONSTRAINT CK_Nama_Penyewa CHECK (nama_petani NOT LIKE '%[0-9]%');

ALTER TABLE Transaksi
ADD CONSTRAINT CK_Harga CHECK (harga_sewa NOT LIKE '%[^0-9]%');

-- 1. Menghapus constraint pengecekan nama yang salah alamat

-- 2. Menghapus constraint pengecekan harga yang salah alamat
ALTER TABLE Transaksi 
DROP CONSTRAINT CK_Harga;

select * from Penyewa;

-- Hapus transaksi yang dilakukan oleh pajar
DELETE FROM Transaksi WHERE id_penyewa = 1015;

-- Baru hapus data pajar dari tabel Penyewa
DELETE FROM Penyewa WHERE id_penyewa = 1015;

-- 1. VIEW untuk Tabel Alat & Kategori
-- Menggabungkan Alat_Mesin dengan Kategori untuk memunculkan nama kategori
CREATE VIEW vw_DaftarAlat AS
SELECT 
    A.id_alat, 
    K.nama_kategori, 
    A.nama_alat, 
    A.merk, 
    A.tipe, 
    A.harga_sewa, 
    A.status_kondisi, 
    A.status_ketersediaan
FROM Alat_Mesin A
JOIN Kategori K ON A.id_kat = K.id_kat;
GO

CREATE PROCEDURE sp_InsertAlat
    @id_kat INT,
    @nama_alat VARCHAR(100),
    @merk VARCHAR(50),
    @tipe VARCHAR(50),
    @harga_sewa DECIMAL(18,2),
    @status_kondisi VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON; 
    BEGIN TRY 
        -- Validasi 1: Cek harga > 0 (Sesuai Modul Hal 7)
        IF @harga_sewa <= 0
            THROW 50001, 'Error: Harga sewa harus lebih besar dari Rp 0.', 1; 

        -- Jika lolos, eksekusi INSERT 
        INSERT INTO Alat_Mesin (id_kat, nama_alat, merk, tipe, harga_sewa, status_kondisi, status_ketersediaan)
        VALUES (@id_kat, @nama_alat, @merk, @tipe, @harga_sewa, @status_kondisi, 'Tersedia');

        PRINT 'Sukses: Alat baru berhasil ditambahkan.'; 
    END TRY
    BEGIN CATCH
        PRINT 'Gagal Tambah Alat.'; 
        THROW; -- Melempar pesan error asli ke C#
    END CATCH
END;
GO

CREATE PROCEDURE sp_UpdateAlat
    @id_alat INT,
    @nama_alat VARCHAR(100),
    @harga_sewa DECIMAL(18,2),
    @status_kondisi VARCHAR(50),
    @status_ketersediaan VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        -- Validasi: Pastikan ID Alat ada di database sebelum update
        IF NOT EXISTS (SELECT 1 FROM Alat_Mesin WHERE id_alat = @id_alat)
            THROW 50002, 'Error: Data alat tidak ditemukan, gagal update.', 1;

        -- Eksekusi UPDATE
        UPDATE Alat_Mesin 
        SET nama_alat = @nama_alat, 
            harga_sewa = @harga_sewa, 
            status_kondisi = @status_kondisi,
            status_ketersediaan = @status_ketersediaan
        WHERE id_alat = @id_alat;

        PRINT 'Sukses: Data alat berhasil diperbarui.';
    END TRY
    BEGIN CATCH
        THROW; 
    END CATCH
END;
GO

CREATE PROCEDURE sp_DeleteAlat
    @id_alat INT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        -- Validasi: Cegah hapus jika alat sedang berstatus 'Disewa'
        IF EXISTS (SELECT 1 FROM Alat_Mesin WHERE id_alat = @id_alat AND status_ketersediaan = 'Disewa')
            THROW 50003, 'Error: Alat sedang disewa, tidak boleh dihapus!', 1;

        -- Eksekusi DELETE
        DELETE FROM Alat_Mesin WHERE id_alat = @id_alat;

        PRINT 'Sukses: Alat berhasil dihapus.';
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;
GO

CREATE PROCEDURE sp_SearchAlat
    @keyword VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        -- Validasi: Keyword pencarian tidak boleh kosong
        IF @keyword IS NULL OR LEN(LTRIM(RTRIM(@keyword))) = 0
            THROW 50004, 'Error: Masukkan kata kunci untuk mencari alat.', 1;

        -- Eksekusi SEARCH menggunakan VIEW vw_DaftarAlat yang sudah dibuat
        SELECT * FROM vw_DaftarAlat 
        WHERE nama_alat LIKE '%' + @keyword + '%' 
           OR merk LIKE '%' + @keyword + '%';
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;
GO


-- 1. Membuat VIEW untuk menampilkan riwayat transaksi (UCP 2 Poin 2)
-- Agar di GridView muncul Nama Petani dan Nama Alat, bukan ID
CREATE VIEW vw_DaftarTransaksi AS
SELECT 
    T.id_transaksi,
    P.nama_petani,
    A.nama_alat,
    T.tgl_sewa,
    T.tgl_kembali,
    T.total_bayar
FROM Transaksi T
JOIN Penyewa P ON T.id_penyewa = P.id_penyewa
JOIN Alat_Mesin A ON T.id_alat = A.id_alat;
GO

ALTER PROCEDURE sp_InsertTransaksi
    @id_alat INT,
    @id_penyewa INT,
    @tgl_sewa DATETIME,
    @tgl_kembali DATETIME,
    @total_bayar DECIMAL(18,2)
AS
BEGIN
    -- Mulai blok penanganan error
    BEGIN TRY
        -- Validasi 1: Cek apakah alat tersedia
        IF NOT EXISTS (SELECT 1 FROM Alat_Mesin WHERE id_alat = @id_alat AND status_ketersediaan = 'Tersedia')
        BEGIN
            -- Jika tidak tersedia, lempar error kustom
            THROW 52001, 'Error: Alat sedang tidak tersedia.', 1;
        END

        -- Validasi 2: Cek logika tanggal
        IF @tgl_kembali < @tgl_sewa
        BEGIN
            -- Jika tanggal salah, lempar error kustom
            THROW 52003, 'Error: Tanggal kembali tidak boleh sebelum tanggal sewa.', 1;
        END

        -- Jika aman, lakukan INSERT ke tabel Transaksi
        INSERT INTO Transaksi (id_alat, id_penyewa, tgl_sewa, tgl_kembali, total_bayar)
        VALUES (@id_alat, @id_penyewa, @tgl_sewa, @tgl_kembali, @total_bayar);

        -- Update status alat otomatis (Otomatisasi Logika)
        UPDATE Alat_Mesin SET status_ketersediaan = 'Disewa' WHERE id_alat = @id_alat;

        PRINT 'Sukses: Transaksi baru berhasil ditambahkan.';
    END TRY
    BEGIN CATCH
        -- Tangkap error dan tampilkan pesannya
        PRINT 'Gagal menambahkan transaksi.';
        PRINT ERROR_MESSAGE();
        
        -- Tetap gunakan THROW agar pesan error sampai ke MessageBox di C#
        THROW; 
    END CATCH
END;
GO
ALTER PROCEDURE sp_InsertTransaksi
    @id_alat INT,
    @id_penyewa INT,
    @tgl_sewa DATETIME,
    @tgl_kembali DATETIME,
    @total_bayar DECIMAL(18,2)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        -- Cek ketersediaan alat
        IF NOT EXISTS (SELECT 1 FROM Alat_Mesin WHERE id_alat = @id_alat AND status_ketersediaan = 'Tersedia')
            THROW 52001, 'Error: Alat sedang tidak tersedia.', 1;

       
        IF @tgl_kembali < @tgl_sewa
            THROW 52003, 'Error: Tanggal kembali tidak boleh sebelum tanggal sewa.', 1;

        --  Cek apakah total bayar masuk akal tidak boleh 0 atau minus
        IF @total_bayar <= 0
            THROW 52004, 'Error: Total bayar tidak valid. Periksa kembali tanggal dan harga alat.', 1;

        -- Jika lolos semua validasi, baru lakukan INSERT
        INSERT INTO Transaksi (id_alat, id_penyewa, tgl_sewa, tgl_kembali, total_bayar)
        VALUES (@id_alat, @id_penyewa, @tgl_sewa, @tgl_kembali, @total_bayar);

        -- Update status alat
        UPDATE Alat_Mesin SET status_ketersediaan = 'Disewa' WHERE id_alat = @id_alat;

        PRINT 'Sukses: Transaksi berhasil dicatat.';
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;
GO



-- 3. VIEW untuk Tabel Penyewa
-- Menampilkan semua data dari tabel Penyewa
CREATE VIEW vw_DaftarPenyewa AS
SELECT 
    id_penyewa, 
    nama_petani, 
    no_hp, 
    alamat
FROM Penyewa;
GO

-- ============================================================
-- 1. STORED PROCEDURE UNTUK TAMBAH PENYEWA
-- Skenario: Validasi panjang nama (min 3 karakter) dan cek duplikasi
-- ============================================================
ALTER PROCEDURE dbo.sp_InsertPenyewa
    @NamaPetani VARCHAR(100),
    @NoHp VARCHAR(15),
    @Alamat TEXT
AS
BEGIN
    -- Mulai blok penanganan error sesuai modul
    BEGIN TRY
        -- Validasi 1: Cek apakah Nama sudah ada (Skenario EXISTS di modul)
        IF EXISTS (SELECT 1 FROM Penyewa WHERE nama_petani = @NamaPetani)
        BEGIN
            THROW 51001, 'Error: Nama Petani tersebut sudah terdaftar gaes.', 1;
        END

        
        IF LEN(@NamaPetani) < 3
        BEGIN
            THROW 51002, 'Error: Nama Lengkap terlalu pendek (min. 3 huruf).', 1;
        END

        -- Jika aman, lakukan INSERT
        INSERT INTO Penyewa (nama_petani, no_hp, alamat)
        VALUES (UPPER(@NamaPetani), @NoHp, @Alamat);

        PRINT 'Sukses: Data penyewa baru berhasil ditambahkan.';
    END TRY
    BEGIN CATCH
        -- Tangkap error dan tampilkan pesannya
        PRINT 'Gagal menambahkan penyewa.';
        PRINT ERROR_MESSAGE();
        
     
        THROW;
    END CATCH
END;
GO

-- ============================================================
-- 2. STORED PROCEDURE UNTUK UPDATE PENYEWA
-- Skenario: Validasi ID ada dan Alamat tidak boleh kosong
-- ============================================================
CREATE PROCEDURE dbo.sp_UpdatePenyewa
    @PenyewaID INT,
    @NamaPetani VARCHAR(100),
    @NoHp VARCHAR(15),
    @Alamat TEXT
AS
BEGIN
    BEGIN TRY
        -- Validasi 1: Cek apakah ID ditemukan
        IF NOT EXISTS (SELECT 1 FROM Penyewa WHERE id_penyewa = @PenyewaID)
        BEGIN
            THROW 51003, 'Error: ID Penyewa tidak ditemukan.', 1;
        END
		IF LEN(@NamaPetani) < 3
        BEGIN
            THROW 51001, 'Error: Nama terlalu pendek.', 1;
        END

        -- Update data
        UPDATE Penyewa 
        SET nama_petani = UPPER(@NamaPetani),
            no_hp = @NoHp,
            alamat = @Alamat
        WHERE id_penyewa = @PenyewaID;

        PRINT 'Sukses: Data penyewa berhasil diperbarui';
    END TRY
    BEGIN CATCH
        PRINT 'Gagal memperbarui data penyewa.';
        PRINT ERROR_MESSAGE();
        THROW;
    END CATCH
END;
GO

-- ============================================================
-- 3. STORED PROCEDURE UNTUK HAPUS PENYEWA
-- Skenario: Validasi relasi ke tabel transaksi
-- ============================================================
CREATE PROCEDURE dbo.sp_DeletePenyewa
    @PenyewaID INT
AS
BEGIN
    BEGIN TRY
        -- Validasi: Jangan hapus jika ada riwayat transaksi
        IF EXISTS (SELECT 1 FROM Transaksi WHERE id_penyewa = @PenyewaID)
        BEGIN
            THROW 51005, 'Error: Data tidak bisa dihapus karena memiliki riwayat transaksi.', 1;
        END

        DELETE FROM Penyewa WHERE id_penyewa = @PenyewaID;
        PRINT 'Sukses: Data penyewa berhasil dihapus.';
    END TRY
    BEGIN CATCH
        PRINT 'Gagal menghapus data penyewa.';
        PRINT ERROR_MESSAGE();
        THROW;
    END CATCH
END;
GO

ALTER VIEW vw_DaftarAlat AS
SELECT 
    A.id_alat, 
    A.id_kat,          -- agar ID muncul untuk binding
    K.nama_kategori,   -- untuk memunculkan nama (Traktor/Drone)
    A.nama_alat, 
    A.merk, 
    A.tipe, 
    A.harga_sewa, 
    A.status_kondisi, 
    A.status_ketersediaan
FROM Alat_Mesin A
JOIN Kategori K ON A.id_kat = K.id_kat;
GO




ALTER TABLE Transaksi DROP CONSTRAINT CK_Nama_Penyewa;
ALTER TABLE Transaksi DROP CONSTRAINT CK_Harga;

select * from Transaksi;

SELECT *
INTO Penyewa_Backup
FROM Penyewa;

SELECT * INTO Transaksi_Backup FROM Transaksi;