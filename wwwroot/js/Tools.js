class Theme {
  static set(theme) {
    document.body.setAttribute("theme", theme);
    document.querySelector("dialog").setAttribute("theme", theme);
  }

  static get() {
    return document.body.getAttribute("theme");
  }

  static swap() {
    this.set(this.get() == "light" ? "dark" : "light");
  }
}

class Sign {
  static check = class {
    static name(name) {
      return /^(?:[A-Z][a-z]+ )+[A-Z][a-z]+$/.test(name);
    }

    static password(pwd) {
      return /^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*.,_-]).{8,16}$/
        .test(pwd);
    }

    static email(email) {
      return /^(?:[a-z0-9!#$%&*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&*+/=?^_`{|}~-]+)*|"(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9]))\.){3}(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9])|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])$/
        .test(email);
    }

    static phone(phone) {
      return /^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$/
        .test(phone);
    }
  }
}