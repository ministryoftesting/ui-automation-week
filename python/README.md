# UI Automation Week Challenges - 🐍 Python edition 🐍

In this section you will find supporting code for challenges 2, 3 and 5.

## Pre-requisites

To run the projects you will need:

* Python 3.5+ (not 3.9.x, since there are compatability issues)
* It's recommended to use a Virtual Environment

## Running challenges

Open a terminal within the `python` directory.

> ⚠️ Make sure you have a virtual environment activated!

Then run the following command to install the dependencies from the `pyproject.toml`:

```bash
python -m pip install .
```

> 💡 You can also manually install each dependency. For example, you may want to use a different formatter or linter than the ones I'm using.

## Pylenium

The only package that you really need to install is `Pylenium`. This is a thin wrapper on top of Selenium WebDriver and includes the Pytest testing framework. However, this means that Selenium is _already_ installed, so if you feel more comfortable with pure Selenium, you can use it directly instead.

> To find out more, visit the [Official Documentation](https://elsnoman.gitbook.io/pylenium/)

```bash
pip install pyleniumio
```
