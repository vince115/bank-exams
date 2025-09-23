// Program.cs  —— 乾淨版：用參數選題
using System;

if (args.Length == 0) { ShowHelp(); return; }

switch (args[0].ToLowerInvariant())
{
    case "q1": RunQ1(); break;
    case "q2": RunQ2(); break;
    case "q3": RunQ3(); break;
    case "q4": RunQ4(); break;
    default: ShowHelp(); break;
}

static void RunQ1()
{
    var id = Q1.CreateAccount("3333333333", "Demo", 500m);
    Console.WriteLine($"Q1: account_id = {id}");
}

static void RunQ2()
{
    // 假設帳戶 1 已存在；不在的話先用 Q1 建一個
    Console.WriteLine($"Q2 deposit  +200 => {Q2.UpdateBalance(1, +200m)}");
    Console.WriteLine($"Q2 withdraw  -50 => {Q2.UpdateBalance(1, -50m)}");
    try { Q2.UpdateBalance(1, -9999m); }
    catch (OverdraftException ex) { Console.WriteLine("[Overdraft] " + ex.Message); }
}

static void RunQ3()
{
    // 若你有 Q3.EnsureSchema()/Seed，可呼叫；沒有就直接查
    var list = Q3.QueryTransactions(1, DateTime.Now.AddDays(-7));
    Console.WriteLine("Q3: amounts since 7d:");
    foreach (var a in list) Console.WriteLine(a);
    Console.WriteLine($"Total: {list.Count}");
}

static void RunQ4()
{
    Console.WriteLine($"Q4 alice/P@ssw0rd => {(Q4.ValidateUser("alice", "P@ssw0rd") ? "OK" : "FAIL")}");
    Console.WriteLine($"Q4 alice/wrong    => {(Q4.ValidateUser("alice", "wrong") ? "OK" : "FAIL")}");
}

static void ShowHelp()
{
    Console.WriteLine("Usage: dotnet run q1|q2|q3|q4");
}
