### 106年臺灣銀行新進人員甄試 - 程式設計人員 
### 科目三：程式設計(含安全程式設計) 與科目二：綜合科目

根據公開資源搜索，106年（2017年）臺灣銀行新進人員甄試的程式設計人員（7職等程式設計人員）專業科目（科目三：程式設計）考題的完整官方版本或詳細題目公開資料有限，僅部分共同科目及綜合科目（如邏輯推理、軟體工程等）的試題可取得（如TKB購課網或考友社的考古題下載區）。 考試日期為106/8/26，錄取名額約45名（正取30、備取15）。考試大綱顯示科目三：100分，非選擇題，涵蓋程式設計與安全程式設計（JAVA+SQL 或 .NET C#+SQL）；科目二：50分，非選擇題，含邏輯推理、軟體工程、系統分析、資料結構、資料庫應用。

為協助準備，以下提供基於106年考試大綱及歷年風格（如107-108年公開試題）的**模擬考題與詳解**（科目三總分100分，每題25分；科目二總分50分）。模擬題目強調安全程式設計（如基本驗證、簡單雜湊）、邏輯推理及UML建模，[適用.NET](http://xn--jny749c.net/) C#+SQL。題型參考鼎文公職、阿摩線上測驗及TKBGO題庫。

## 科目三：程式設計(含安全程式設計)（100分，非選擇題）

**題目要求**：[使用.NET](http://xn--2rqz13g.net/) C# + SQL，注重安全（如輸入驗證、參數化）。每題25分。

### **題1：帳戶建立模組（含驗證）【25分】**

設計銀行帳戶建立。資料庫表：

```sql
CREATE TABLE Accounts (
    account_id INT IDENTITY(1,1) PRIMARY KEY,
    account_no VARCHAR(20) NOT NULL UNIQUE,
    owner_name VARCHAR(50) NOT NULL,
    initial_balance DECIMAL(10,2) DEFAULT 0.00,
    created_date DATETIME DEFAULT GETDATE()
);

```

- （一）撰寫SQL插入帳戶（使用參數化，檢查account_no唯一）（8分）。
- （二）在C#中實現`int CreateAccount(string accountNo, string ownerName, decimal initialBalance)`，驗證accountNo（10位數字）、initialBalance ≥0；若重複拋出`AccountExistsException`（12分）。
- （三）說明參數化防SQL注入（5分）。


&nbsp; 
---


### **題2：餘額更新系統【25分】**

設計餘額更新。表：Accounts (account_id INT PK, balance DECIMAL(10,2))。

- （一）SQL更新餘額（加減amount）（8分）。
- （二）C#實現`bool UpdateBalance(int accountId, decimal amount)`，若amount <0檢查餘額，使用Transaction；若不足拋出`OverdraftException`（12分）。
- （三）說明Transaction在更新的角色（5分）。


&nbsp; 
---
### **題3：交易查詢模組【25分】**

設計交易查詢。表：Transactions (trans_id INT PK, account_id INT, amount DECIMAL(10,2), trans_date DATETIME)。

- （一）SQL查詢指定帳戶交易（加索引）（8分）。
- （二）C#實現`List<decimal> QueryTransactions(int accountId, DateTime fromDate)`（12分）。
- （三）說明索引優化（5分）。

&nbsp; 
---
### **題4：簡單加密驗證【25分】**

設計登入驗證，使用簡單雜湊。表：Users (user_id INT PK, username VARCHAR(50), password_hash VARCHAR(32))。

- （一）SQL查詢驗證（8分）。
- （二）C#實現`bool ValidateUser(string username, string password)`，計算MD5比對（12分）。
- （三）說明雜湊安全性（5分）。

&nbsp; 
===

## 科目二：綜合科目（50分，非選擇題）


模擬題型參考106年綜合科目，含(1)邏輯推理（15分）(2)軟體工程（15分）(3)系統分析（10分）(4)資料結構（5分）(5)資料庫應用（5分）。

**(1) 邏輯推理（15分）**

A猜「1357」，B回「1A 1B」；再猜「2468」，B回「0A 2B」。

- （一）第一輪可能底牌總數（6分）。
- （二）結合第二輪，列3示例（5分）。
- （三）猜中機率（4分）。



---

**(2) 軟體工程（15分）**

繪UML序列圖給轉帳：User→System→DB。

- （一）文字描述圖（10分）。
- （二）應用於除錯（5分）。

---

**(3) 系統分析（10分）**

UML用例圖給銀行系統：登入、轉帳。

- （一）文字描述（6分）。
- （二）Actor關聯（4分）。

---  

**(4) 資料結構（5分）**

設計堆疊管理交易，push/pop O(1)。

- （一）C#偽碼（3分）。
- （二）應用（2分）。

---

**(5) 資料庫應用（5分）**

GROUP BY查詢交易總額。

- （一）SQL（3分）。
- （二）HAVING說明（2分）。