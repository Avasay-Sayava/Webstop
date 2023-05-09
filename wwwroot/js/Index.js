class Theme {
  static set = (theme) => {
    document.body.setAttribute("theme", theme);
    return Cookies.set("theme", theme);
  }

  static get = () => {
    return document.body.getAttribute("theme");
  }

  static swap = () => {
    return this.set(this.get() ? "dark" : "light");
  }
}

class Cookies {
  static set = (name, value, expires = 30, force = false) => {
    if ((this.get("allow") == null || name == "allow") && !force)
      return new Promise();
    let d = new Date();
    d.setTime(new Date().getTime() + expires * 24 * 60 * 60 * 1000);
    document.cookie = `${name}=${value}; expires=${d.toUTCString()}`;
    location.reload();
    return new Promise();
  }

  static get = (name = null) => {
    let cookies = document.cookie.split('; ');
    if (name == null) {
      for (var cookie in cookies)
        cookie = cookie.substring(cookie.split("=")[0].length + 1);
      return cookies
    } else {
      for (var cookie in cookies)
        if (cookie.split("=")[0] == name)
          return cookie.substring(name.length + 1);
      return null;
    }
  }

  static clear = (force = false) => {
    for (var cookie in this.get())
      this.set(cookie, "null", 0, force);
    return new Promise();
  }

  static accept = () => {
    return this.set("allow", "true", true).then(() => {
      return Theme.set(Theme.get());
    });
  }

  static decline = () => {
    return this.clear(true);
  }
}

class Sign {
  static check = class {
    static name = (name) => {
      return /^(?:[A-Z][a-z]+ )+[A-Z][a-z]+$|^(?:[\u05D0-\u05EA]{2,} )+[\u05D0-\u05EA]{2,}$/.test(name);
    }

    static password = (pwd) => {
      return /^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$ %^&*-]).{8,}$/.test(pwd);
    }

    static email = (email) => {
      return /^(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|"(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9]))\.){3}(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9])|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])$/.test(email);
    }
      
    static phone = (phone) => {
      return /^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$/.test(phone);
    }
  }
}