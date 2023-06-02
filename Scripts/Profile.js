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

document.getElementById("submit").addEventListener('click', (e) => {
  if ((!Sign.check.name(document.getElementById("name").value))) {
    // If name validation fails, show the label associated with the name input
    showLabel(document.getElementById("name"), 0);
    e.preventDefault(); // Prevent form submission
  }
  if ((!Sign.check.password(document.getElementById("password").value))) {
    // If password validation fails, show the label associated with the password input
    showLabel(document.getElementById("password"), 0);
    e.preventDefault(); // Prevent form submission
  }
  if (!(Sign.check.email(document.getElementById("email").value))) {
    // If email validation fails, show the label associated with the email input
    showLabel(document.getElementById("email"), 0);
    e.preventDefault(); // Prevent form submission
  }
});