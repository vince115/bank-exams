
```mermaid
stateDiagram-v2
  %% 線上訂單系統：狀態圖
  [*] --> 未處理訂單 : 新訂單進來

  未處理訂單 --> 接受訂單 : 可接單[是]
  未處理訂單 --> 拒絕訂單 : 可接單[否]

  拒絕訂單 --> [*] : 結案

  接受訂單 --> 已完成訂單 : 全部貨品已備妥[是]
  接受訂單 --> 待處理訂單 : 全部貨品已備妥[否]

  待處理訂單 --> 已完成訂單 : 貨品補齊

  已完成訂單 --> [*] : 結案
```

---

### （一）UML 類別圖的目的（要點）

> - 描述系統的靜態結構：有哪些類別（物件型別）、它們的屬性與方法。
> - 呈現類別之間的關係：關聯（含多重度/角色名）、聚合/組合、一般化（繼承）、相依。
> - 做為分析與設計的共同語言：利於需求溝通、設計討論、產生程式碼與維護。
> - 協助資料模型與模組邊界的規畫：清楚界定責任與耦合度，提升可重用與可維護性。


### （二）類別圖（依敘述）

> - 學生 Student：可修 1..8 門課。
> - 課程 Course：可能 0..* 位學生修讀；由 1..2 位老師授課。
> - 老師 Teacher：可教 1..* 門課。

```mermaid
classDiagram
  class Student {
    +id: String
    +name: String
  }
  class Course {
    +code: String
    +title: String
  }
  class Teacher {
    +id: String
    +name: String
  }

  %% 學生與課程：Student 1..8 修課；Course 0..* 被修
  Student "1..8" -- "0..*" Course : enrolls

  %% 老師與課程：Teacher 1..* 任教；Course 1..2 授課
  Teacher "1..*" -- "1..2" Course : teaches

```
---
