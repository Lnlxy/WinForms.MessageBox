# WinForms.MessageBox
封装以 `System.Windows.Forms.MessageBoxIcon` 枚举图标风格的多种创建`MessageBox`的方法。支持自定义按钮显示的文本及按钮点击的返回值和方法。

## 用法

1. **基本用法**

```c#
MessageBoxService.Question("text", "title").AsYesNoBehavior()
                .OnYes(() =>
                {
                    //yes button click todo;
                })
                .OnNo(() =>
                {
                    //no button click todo;
                }).Show();
```

2. **操作返回值**

```c#
var result = MessageBoxService.Question("text", "title").AsYesNoBehavior<int>()
                .OnYes(() =>
                {
                    //yes button click todo;
                    return 1;
                })
                .OnNo(() =>
                {
                    //no button click todo;
                    return -1; 
                }).Show();
```

3. **修改指定按钮显示文本**

```c#
MessageBoxService.Question("Agree?", "select...").AsYesNoBehavior()
                .SetYesText("Agree!")
                .SetNoText("No!")
                .OnYes(() =>
                {
                    //do agree code;
                })
                .OnNo(() =>
                {
                    //do disagree code;
                }).Show();
```

