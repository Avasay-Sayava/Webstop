/**
 * Performs a search on the table rows based on user input.
 */
function search() {
  const divs = document.getElementsByClassName("result");

  const input = document.getElementById(`search`);
  const filter = input.value.toUpperCase().replace("HTTPS://", "").replace("/", "");

  for (var i = 0; i < divs.length; i++) {
    const div = divs[i];
    const txtValue = div.getElementsByTagName("p")[i].innerText;
    div.style.display = txtValue.toUpperCase().replace("HTTPS://", "").replace("/", "").indexOf(filter) > -1 ? "" : "none";
  }
}

// Attach event listeners to search input field
document.getElementById(`search`).addEventListener("keyup", search);
document.getElementById(`search`).addEventListener("change", search);

/**
 * Hides the label associated with an element.
 * @param {HTMLElement} element - The input element.
 * @param {number} i - The index of the label.
 */
function hideLabel(element, i) {
  element.labels[i].style.position = "absolute";
  element.labels[i].style.visibility = "hidden";
}

/**
 * Shows the label associated with an element.
 * @param {HTMLElement} element - The input element.
 * @param {number} i - The index of the label.
 */
function showLabel(element, i) {
  element.labels[i].style.position = "relative";
  element.labels[i].style.visibility = "visible";
}

document.getElementById("dialog_submit").addEventListener('click', e => {
  /**
   * Validates the input value using a regular expression.
   * Regular Expression: /^(?:https:\/\/)?(?:www\.)?(?:(?!www\.)[A-Za-z\d]{2,}\.)+[A-Za-z\d]{2,}\/?$/
   * Explanation:
   *   ^ - Start of the input
   *   (?:https:\/\/)? - Optional "https://" at the beginning
   *   (?:www\.)? - Optional "www." in the domain
   *   (?:(?!www\.)[A-Za-z\d]{2,}\.)+ - One or more subdomains (not starting with "www.")
   *   [A-Za-z\d]{2,} - Domain name consisting of at least two alphanumeric characters
   *   \/?$ - Optional "/" at the end of the input
   * @aoutomata {finite} https://embed.ihateregex.io/make/JTVFKCUzRiUzQWh0dHBzJTNBJTVDJTVDJTJGJTVDJTVDJTJGKSUzRiglM0YlM0F3d3clNUMlNUMuKSUzRiglM0YlM0EoJTNGIXd3dyU1QyU1Qy4pJTVCQS1aYS16JTVDJTVDZCU1RCU3QjIlMkMlN0QlNUMlNUMuKSUyQiU1QkEtWmEteiU1QyU1Q2QlNUQlN0IyJTJDJTdEJTVDJTVDJTJGJTNGJTI0
   */
  if (!/^(?:https:\/\/)?(?:www\.)?(?:(?!www\.)[A-Za-z\d]{2,}\.)+[A-Za-z\d]{2,}\/?$/.test(document.getElementById("dialog_input").value)) {
    // If input value fails validation, show the label associated with the input
    showLabel(document.getElementById("dialog_input"), 0);
    e.preventDefault(); // Prevent form submission
  } else {
    // If input value passes validation, hide the label and process the input value
    hideLabel(document.getElementById("dialog_input"), 0);
    document.getElementById("dialog_input").value = document.getElementById("dialog_input").value.toLowerCase().replace("https://", "").replace("/", "");
  }
});