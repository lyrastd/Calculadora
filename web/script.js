let displayValue = '0';
const display = document.getElementById('display');
function updateDisplay() { display.value = displayValue; }
function appendNumber(num) { if (displayValue === '0') displayValue = num; else displayValue += num; updateDisplay(); }
function appendOperator(op) { const lastChar = displayValue.slice(-1); if (['+','-','*','/'].includes(lastChar)) displayValue = displayValue.slice(0, -1); displayValue += op; updateDisplay(); }
function clearDisplay() { displayValue = '0'; updateDisplay(); }
function deleteLast() { if (displayValue.length > 1) displayValue = displayValue.slice(0, -1); else displayValue = '0'; updateDisplay(); }
function calculate() { try { displayValue = eval(displayValue).toString(); updateDisplay(); } catch { displayValue = 'Erro'; updateDisplay(); setTimeout(clearDisplay, 1500); } }