# 🛡️ Pengujian Keamanan (SQL Injection Test)

Bagian ini mendokumentasikan simulasi serangan **SQL Injection** pada form input untuk memastikan keamanan data sistem.

### 1. Percobaan Input Query
Melakukan input query `' OR 1=1--` ke dalam kolom nama petani untuk mencoba memanipulasi logika database.
<img src="https://github.com/user-attachments/assets/710af21b-3013-4fc5-80c0-2ae95de71a38" width="600" alt="Input SQL Injection" />

### 2. Status Berhasil Manipulasi
Data berhasil berubah menjadi "HACKED" setelah query dieksekusi oleh sistem.
<img src="https://github.com/user-attachments/assets/f3b32409-d4bc-4fc5-8e41-9f99a7466d7b" width="600" alt="Data Terubah" />

### 3. Proses Reset Data
Setelah data berubah menjadi "HACKED", langkah selanjutnya adalah menguji fungsi tombol Reset Data.
<img src="https://github.com/user-attachments/assets/b6fae3be-daa0-4c04-bddc-85a6d435a9aa" width="600" alt="Klik Reset Data" />

### 4. Pemulihan Data
Data berhasil kembali ke kondisi semula seperti sebelum dilakukan input manipulasi.
<img src="https://github.com/user-attachments/assets/40f6093c-5c1e-4088-b016-c3d7c55e17b1" width="600" alt="Data Kembali Semula" />

---

<details>
  <summary>Klik untuk melihat detail screenshot lainnya</summary>
  
  <br />
  <img src="https://github.com/user-attachments/assets/6cd8e70e-08a1-494c-a7c1-a464aede2531" width="400" />
  <img src="https://github.com/user-attachments/assets/e0b37842-7098-4da5-ac6a-6b395b1e1f3d" width="400" />
  <img src="https://github.com/user-attachments/assets/98c5a080-954b-42e7-bbd1-15dce1956614" width="400" />
  <img src="https://github.com/user-attachments/assets/b718275a-275b-4ab0-8e3c-3603df89ed76" width="400" />
</details>
