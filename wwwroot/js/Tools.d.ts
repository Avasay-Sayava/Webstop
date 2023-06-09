declare class Theme {
  /**
   * Set the theme.
   * @param {string} theme - The theme to set.
   * @returns {void}
   */
  static set(theme: string): void;

  /**
   * Get the currently set theme.
   * @returns {string} - The current theme.
   */
  static get(): string;

  /**
   * Swap between the current theme and the opposite theme.
   * @returns {void}
   */
  static swap(): void;
}

declare class Sign {
  static check: {
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
    name(name: string): boolean;

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
    password(pwd: string): boolean;

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
    email(email: string): boolean;
  };
}