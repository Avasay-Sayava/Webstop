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
     *   [a-z0-9!#$%&*+/=?^_`{|}~-]+     - One or more valid email characters (local part)
     *   (?:\.[a-z0-9!#$%&*+/=?^_`{|}~-]+)* - Zero or more sequences of a dot followed by valid email characters (domain parts)
     *   |                               - Alternation (or)
     *   "                               - Opening double quote (for quoted email)
     *   (?:                             - Start of non-capturing group
     *   [\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f] - Valid ASCII characters for the quoted string (excluding double quote and backslash)
     *   |                               - Alternation (or)
     *   \\[\x01-\x09\x0b\x0c\x0e-\x7f]  - Valid escaped characters in the quoted string
     *   )*                              - Zero or more sequences of valid characters or escaped characters in the quoted string
     *   "                               - Closing double quote (for quoted email)
     *   )@                              - End of local part and '@' symbol
     *   (?:                             - Start of non-capturing group
     *   (?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+ - One or more subdomains (not starting with a hyphen)
     *   [a-z0-9](?:[a-z0-9-]*[a-z0-9])? - Domain name consisting of at least two alphanumeric characters
     *   |                               - Alternation (or)
     *   \[                              - Opening square bracket (for IP address)
     *   (?:                             - Start of non-capturing group
     *   (?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9]))\. - IP address segments (numbers between 0 and 255)
     *   ){3}                            - Three occurrences of IP address segments
     *   (?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9])|[a-z0-9-]*[a-z0-9] - Fourth IP address segment or domain name (not starting with a hyphen)
     *   :                               - Colon separator (for port number)
     *   (?:                             - Start of non-capturing group
     *   [\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f] - Valid ASCII characters for the port number (excluding double quote and backslash)
     *   |                               - Alternation (or)
     *   \\[\x01-\x09\x0b\x0c\x0e-\x7f]  - Valid escaped characters in the port number
     *   )+                              - One or more sequences of valid characters or escaped characters in the port number
     *   )                               - End of non-capturing group
     *   \]                              - Closing square bracket (for IP address)
     *   )                               - End of non-capturing group
     *   $                               - End of the input
     * @automata {finite} https://embed.ihateregex.io/make/JTVFKCUzRiUzQSU1QmEtejAtOSElMjMlMjQlMjUlMjYnKiUyQiUyRiUzRCUzRiU1RV8lNjAlN0IlN0MlN0R-LSU1RCUyQiglM0YlM0ElNUMlNUMuJTVCYS16MC05ISUyMyUyNCUyNSUyNicqJTJCJTJGJTNEJTNGJTVFXyU2MCU3QiU3QyU3RH4tJTVEJTJCKSolN0MlMjIoJTNGJTNBJTVCJTVDJTVDeDAxLSU1QyU1Q3gwOCU1QyU1Q3gwYiU1QyU1Q3gwYyU1QyU1Q3gwZS0lNUMlNUN4MWYlNUMlNUN4MjElNUMlNUN4MjMtJTVDJTVDeDViJTVDJTVDeDVkLSU1QyU1Q3g3ZiU1RCU3QyU1QyU1QyU1QyU1QyU1QiU1QyU1Q3gwMS0lNUMlNUN4MDklNUMlNUN4MGIlNUMlNUN4MGMlNUMlNUN4MGUtJTVDJTVDeDdmJTVEKSolMjIpJTQwKCUzRiUzQSglM0YlM0ElNUJhLXowLTklNUQoJTNGJTNBJTVCYS16MC05LSU1RColNUJhLXowLTklNUQpJTNGJTVDJTVDLiklMkIlNUJhLXowLTklNUQoJTNGJTNBJTVCYS16MC05LSU1RColNUJhLXowLTklNUQpJTNGJTdDJTVDJTVDJTVCKCUzRiUzQSglM0YlM0EoMig1JTVCMC01JTVEJTdDJTVCMC00JTVEJTVCMC05JTVEKSU3QzElNUIwLTklNUQlNUIwLTklNUQlN0MlNUIxLTklNUQlM0YlNUIwLTklNUQpKSU1QyU1Qy4pJTdCMyU3RCglM0YlM0EoMig1JTVCMC01JTVEJTdDJTVCMC00JTVEJTVCMC05JTVEKSU3QzElNUIwLTklNUQlNUIwLTklNUQlN0MlNUIxLTklNUQlM0YlNUIwLTklNUQpJTdDJTVCYS16MC05LSU1RColNUJhLXowLTklNUQlM0EoJTNGJTNBJTVCJTVDJTVDeDAxLSU1QyU1Q3gwOCU1QyU1Q3gwYiU1QyU1Q3gwYyU1QyU1Q3gwZS0lNUMlNUN4MWYlNUMlNUN4MjEtJTVDJTVDeDVhJTVDJTVDeDUzLSU1QyU1Q3g3ZiU1RCU3QyU1QyU1QyU1QyU1QyU1QiU1QyU1Q3gwMS0lNUMlNUN4MDklNUMlNUN4MGIlNUMlNUN4MGMlNUMlNUN4MGUtJTVDJTVDeDdmJTVEKSUyQiklNUMlNUMlNUQpJTI0
     * @param {string} email - The email to check.
     * @returns {boolean} - True if the email is valid, false otherwise.
     */
    static email(email) {
      return /^(?:[a-z0-9!#$%&*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&*+/=?^_`{|}~-]+)*|"(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9]))\.){3}(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9])|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])$/
        .test(email);
    }

    /**
     * Validates a phone number input value using a regular expression.
     * Explanation:
     *   ^               - Start of the input
     *   [\+]?           - Optional "+" character
     *   [(]?            - Optional "(" character
     *   [0-9]{3}        - Exactly three digits (0-9)
     *   [)]?            - Optional ")" character
     *   [-\s\.]?        - Optional "-" or whitespace or "." character
     *   [0-9]{3}        - Exactly three digits (0-9)
     *   [-\s\.]?        - Optional "-" or whitespace or "." character
     *   [0-9]{4,6}      - Four to six digits (0-9)
     *   $               - End of the input
     * Check if a phone number is valid.
     * @automata {finite} https://embed.ihateregex.io/make/JTVFJTVCJTVDJTVDJTJCJTVEJTNGJTVCKCU1RCUzRiU1QjAtOSU1RCU3QjMlN0QlNUIpJTVEJTNGJTVCLSU1QyU1Q3MlNUMlNUMuJTVEJTNGJTVCMC05JTVEJTdCMyU3RCU1Qi0lNUMlNUNzJTVDJTVDLiU1RCUzRiU1QjAtOSU1RCU3QjQlMkM2JTdEJTI0
     * @param {string} phone - The phone number to check.
     * @returns {boolean} - True if the phone number is valid, false otherwise.
     */
    static phone(phone) {
      return /^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$/
        .test(phone);
    }
  }
}

// Sets the theme to light
Theme.set("light");