class Theme {
  /**
   * Set the theme and save it in a cookie.
   * @param {string} theme - The theme to set.
   * @returns {Promise<string>} - A Promise that resolves to the saved theme.
   */
  static set(theme) {
    document.body.setAttribute("theme", theme);
    return Cookies.set("theme", theme);
  }

  /**
   * Get the currently set theme.
   * @returns {string} - The current theme.
   */
  static get() {
    return document.body.getAttribute("theme");
  }

  /**
   * Swap between the current theme and the opposite theme.
   * @returns {Promise<string>} - A Promise that resolves to the updated theme.
   */
  static swap() {
    return this.set(this.get() ? "dark" : "light");
  }
}

class Cookies {
  /**
   * Set a cookie with the specified name, value, and expiration date.
   * @param {string} name - The name of the cookie.
   * @param {string} value - The value of the cookie.
   * @param {number} expires - The expiration period in days.
   * @param {boolean} force - Force setting the cookie even if the "allow" cookie is not set.
   * @returns {Promise<void>} - A promise that resolves when the cookie is set.
   */
  static set(name, value, expires = 30, force = false) {
    if ((this.get("allow") == null || name == "allow") && !force)
      return Promise.resolve();
    let d = new Date();
    d.setTime(new Date().getTime() + expires * 24 * 60 * 60 * 1000);
    document.cookie = `${name}=${value}; expires=${d.toUTCString()}`;
    location.reload();
    return Promise.resolve();
  }

  /**
   * Get the value of a cookie with the specified name.
   * If no name is provided, returns an array of all cookies.
   * @param {string|null} name - The name of the cookie to get.
   * @returns {string|null|Array<string>} - The value of the cookie, null if not found, or an array of all cookies.
   */
  static get(name = null) {
    let cookies = document.cookie.split('; ');
    if (name == null) {
      return cookies.map(cookie => cookie.substring(cookie.split("=")[0].length + 1));
    } else {
      for (var cookie of cookies) {
        if (cookie.split("=")[0] == name)
          return cookie.substring(name.length + 1);
      }
      return null;
    }
  }

  /**
   * Clear all cookies.
   * @param {boolean} force - Force clearing the cookies even if the "allow" cookie is not set.
   * @returns {Promise<void>} - A promise that resolves when the cookies are cleared.
   */
  static clear(force = false) {
    for (var cookie of this.get()) {
      this.set(cookie, "null", 0, force);
    }
    return Promise.resolve();
  }

  /**
   * Accept the use of cookies by setting the "allow" cookie and updating the theme.
   * @returns {Promise<void>} - A promise that resolves when the "allow" cookie is set and the theme is updated.
   */
  static accept() {
    return this.set("allow", "true", true).then(() => {
      return Theme.set(Theme.get());
    });
  }

  /**
   * Decline the use of cookies by clearing all cookies.
   * @returns {Promise<void>} - A promise that resolves when all cookies are cleared.
   */
  static decline() {
    return this.clear(true);
  }
}

class Sign {
  static check = class {
    /**
     * Check if a name is valid.
     * @param {string} name - The name to check.
     * @returns {boolean} - True if the name is valid, false otherwise.
     */
    static name(name) {
      return /^(?:[A-Z][a-z]+ )+[A-Z][a-z]+$/.test(name);
    }

    /**
     * Check if a password is valid.
     * @param {string} pwd - The password to check.
     * @returns {boolean} - True if the password is valid, false otherwise.
     */
    static password(pwd) {
      return /^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*.,_-]).{8,16}$/.test(
        pwd
      );
    }

    /**
     * Check if an email is valid.
     * @param {string} email - The email to check.
     * @returns {boolean} - True if the email is valid, false otherwise.
     */
    static email(email) {
      return /^(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|"(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9]))\.){3}(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9])|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])$/.test(
        email
      );
    }

    /**
     * Check if a phone number is valid.
     * @param {string} phone - The phone number to check.
     * @returns {boolean} - True if the phone number is valid, false otherwise.
     */
    static phone(phone) {
      return /^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$/.test(
        phone
      );
    }
  };
}

class Url {
  /**
   * Get the value of a URL parameter by its name.
   * @param {string} name - The name of the parameter.
   * @returns {string|null} - The value of the parameter or null if not found.
   */
  static param(name) {
    var url = window.location.search.substring(1);
    var vars = url.split("&");
    for (var param of vars) {
      var params = param.split("=");
      if (params[0] == name) return params[1];
    }
    return null;
  }
}