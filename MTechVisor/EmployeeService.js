// Base URL of your API
const baseUrl = 'https://localhost:7172/api/Employee/';

// Function to create a new employee
async function createEmployee(employee) {
  try {
    const response = await fetch(baseUrl + 'CreateEmployee', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(employee)
    });
    if (!response.ok) {
      alert("Check the RFC, theres something wrong");
      throw new Error('Failed to create employee');
    }
    return await response.json();
  } catch (error) {
    console.error('Error creating employee:', error);
    throw error;
  }
}

// Function to modify an existing employee
async function modifyEmployee(id, employee) {
  try {
    const response = await fetch(baseUrl + 'ModifyEmployee/' + id, {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(employee)
    });
    if (!response.ok) {
      alert("Check the RFC, theres something wrong");
      throw new Error('Failed to modify employee');
    }
    return await response.json();
  } catch (error) {
    console.error('Error modifying employee:', error);
    throw error;
  }
}


// Function to get an employee by ID
async function getEmployeeById(id) {
  const response = await fetch(baseUrl + 'GetEmployeeByID/' + id);
  return await response.json();
}

// Function to delete an employee
async function deleteEmployee(id) {
  const response = await fetch(baseUrl + 'DeleteEmployee?ID=' + id, {
    method: 'DELETE'
  });
  return await response.json();
}

// Function to get all employees
async function getAllEmployees() {
  const response = await fetch(baseUrl + 'GetAllEmployees');
  return await response.json();
}

// Function to get all employees who have a specific name
async function getAllEmployeesWhoHave(name) {
  const response = await fetch(baseUrl + 'Search/' + name);
  return await response.json();
}
