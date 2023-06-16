class Theme {
  /**
   * Set the theme.
   * @param {string} theme - The theme to set.
   * @returns {void}
   */
  static set(theme) {
    document.body.setAttribute("theme", theme);
    document.querySelector("dialog").setAttribute("theme", theme);
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
   * @returns {void}
   */
  static swap() {
    this.set(this.get() == "light" ? "dark" : "light");
  }
}

class Sign {
  static check = class {
    /**
     * Regular expression for name validation.
     *
     * Explanation:
     *   ^                   - Start of the input
     *   (?:                 - Non-capturing group
     *     [A-Z][a-z]+       - Match an uppercase letter followed by one or more lowercase letters
     *     \s                - Match a whitespace character
     *   )+                  - Match the group one or more times
     *   [A-Z][a-z]+         - Match an uppercase letter followed by one or more lowercase letters
     *   $                   - End of the input
     * @automata {finite} https://embed.ihateregex.io/make/JTVFKCUzRiUzQSU1QkEtWiU1RCU1QmEteiU1RCUyQiUyMCklMkIlNUJBLVolNUQlNUJhLXolNUQlMkIlMjQ
     * @param {string} name - The name to check.
     * @returns {boolean} - True if the name is valid, false otherwise.
     */
    static name(name) {
      return /^(?:[A-Z][a-z]+ )+[A-Z][a-z]+$/.test(name);
    }

    /**
     * Regular expression for password validation.
     * Explanation:
     *   ^                  - Start of the input
     *   (?=.*?[A-Z])       - Positive lookahead for at least one uppercase letter
     *   (?=.*?[a-z])       - Positive lookahead for at least one lowercase letter
     *   (?=.*?[0-9])       - Positive lookahead for at least one digit
     *   (?=.*?[#?!@$%^&*.,_-]) - Positive lookahead for at least one special character
     *   .{8,16}            - Match any character between 8 and 16 times
     *   $                  - End of the input
     * @automata {finite} https://embed.ihateregex.io/make/JTVFKCUzRiUzRC4qJTNGJTVCQS1aJTVEKSglM0YlM0QuKiUzRiU1QmEteiU1RCkoJTNGJTNELiolM0YlNUIwLTklNUQpKCUzRiUzRC4qJTNGJTVCJTIzJTNGISU0MCUyNCUyNSU1RSUyNiouJTJDXy0lNUQpLiU3QjglMkMxNiU3RCUyNA
     * @param {string} pwd - The password to check.
     * @returns {boolean} - True if the password is valid, false otherwise.
     */
    static password(pwd) {
      return /^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*.,_-]).{8,16}$/
        .test(pwd);
    }

    /**
     * Validates an email input value using a regular expression.
     * Explanation:
     *   ^                               - Start of the input
     *   (?:                             - Start of non-capturing group
     *   [a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]  - Match any valid email character
     *   )+                              - Match the group one or more times
     *   @                               - Match the @ symbol
     *   (?:                             - Start of non-capturing group
     *   [a-zA-Z0-9-]                    - Match any valid domain character
     *   )+                              - Match the group one or more times
     *   \.                              - Match the dot (.) symbol
     *   [a-zA-Z]{2,}                    - Match the top-level domain (e.g., .com, .net, .org)
     *   $                               - End of the input
     * @automata {finite} https://embed.ihateregex.io/make/JTVFKCUzRiUzRC4qJTNGJTVCJTIzJTNGISU0MCUyNCUyNSU1RSUyNiouJTJDXy0lNUQpLiU3QjglMkMxNiU3RCUyNA
     * @param {string} email - The email address to check.
     * @returns {boolean} - True if the email is valid, false otherwise.
     */
    static email(email) {
      return /^(?:[a-z0-9!#$%&*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&*+/=?^_`{|}~-]+)*|"(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9]))\.){3}(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9])|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])$/
        .test(email);
    }
  }
}