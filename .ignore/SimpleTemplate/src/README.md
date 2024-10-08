# :clipboard: The 'Test' Documentation :clipboard:

The 'Test' Documentation for a 'Test' class

---

## Table of contents

| Method | Description |
|-|-|
| [Test::Write](#testwrite)| This is some example text so this is longer then it should be to simulate actual data being here |
| [Test::Read](#testread) | This is some example text so this is longer then it should be to simulate actual data being here 

Now onto the first  method!

---

## Methods

### 'Test::Write'

**Description**: This is some sample text to see how this documentation would look with actual data here

**Signature**: void Write(T value)

**Parameters**:

- `T` (Template): This can only be an INT or STD::STRING! (Example text)
- `value` (various types): Some more sample text so i can see what it would be like to have data here!

**Return Type**: `void`

**Usage Example**

```cpp
Test::Write("Hello world!"); // Output: Hello world!
Test::Write(3);              // Output: 3
```

---


### 'Test::Read'

**Description**: This is some sample text to see how this documentation would look with actual data here

**Signature**: `std::string Read()`

**Return Type**: `std::string`

Input user has entered in console

**Usage Example**

```cpp
std::string result = Test::Read(); // Whatever the user inputs to the console
Test::Write(result);               // Output: Whatever the users input was
```

---

