# PutridParrot.Text

[![Build PutridParrot.Text](https://github.com/putridparrot/PutridParrot.Text/actions/workflows/build.yml/badge.svg)](https://github.com/putridparrot/PutridParrot.Text/actions/workflows/build.yml)
[![NuGet version (PutridParrot.Text)](https://img.shields.io/nuget/v/PutridParrot.Text.svg?style=flat-square)](https://www.nuget.org/packages/PutridParrot.Text/)
[![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg)](https://github.com/putridparrot/PutridParrot.Text/blob/master/LICENSE.md)
[![GitHub Releases](https://img.shields.io/github/release/putridparrot/PutridParrot.Text.svg)](https://github.com/putridparrot/PutridParrot.Text/releases)
[![GitHub Issues](https://img.shields.io/github/issues/putridparrot/PutridParrot.Text.svg)](https://github.com/putridparrot/PutridParrot.Text/issues)

Various string/text methods

## Convenience methods

**IsNullOrEmpty**

```
"Hello".IsNullOrEmpty()
```

**IsNullOrWhiteSpace**

```
"Hello".IsNullOrWhiteSpace()
```

## Case based methods

**ToFirstUpper**

```
var s = "hello".ToFirstUpper();
Assert.AreEqual("Hello", s);
```

**ToFirstLower**

```
var s = "Hello".ToFirstLower();
Assert.AreEqual("hello", s);
```

## Conversion based methods

**ToStream**

```
"hello".ToStream();
```
