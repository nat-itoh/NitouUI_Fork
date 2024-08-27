using UnityEngine;
using VContainer;

// �擪��[Logger]��t���ă��O�o�͂���N���X
public sealed class Logger {
    public void Log(string message) => Debug.Log("[Logger] " + message);
}

// �����Z���邾���̃N���X
public sealed class Calculator {
    public int Add(int a, int b) => a + b;
}



// Logger��Calculator�Ɉˑ�����N���X
public sealed class HogeClass {
    private readonly Logger logger;
    private readonly Calculator calculator;

    [Inject]
    public HogeClass(Logger logger, Calculator calculator) {
        this.logger = logger;
        this.calculator = calculator;
    }

    public void LoggerTest() {
        logger.Log("LoggerTest");
    }

    public void CalculatorTest(int a, int b) {
        int result = calculator.Add(a, b);
        logger.Log($"{a} + {b} = {result}");
    }
}

