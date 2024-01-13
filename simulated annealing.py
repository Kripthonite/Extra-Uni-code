import math
import random
import time







# Função de custo
def objective_function(x1, x2):
    return (x1**5 - 81 * x1**4 + 2330 * x1**3 - 28750 * x1**2 + 150000 * x1 +
            0.5 * x2**5 - 65 * x2**4 + 2950 * x2**3 - 53500 * x2**2 + 305000 * x2)

# Função de restrição
def constraints(x1, x2):
    return x1 + 2 * x2 <= 110 and 3 * x1 + x2 <= 120 and 0 <= x1 <= 36 and 0 <= x2 <= 50

# Função de vizinhança
def get_neighbor(x, step_size):
    x_new = [xi + random.uniform(-step_size, step_size) for xi in x]
    return x_new

# Função de aceitação
def safe_exp(x):
    max_exp = 700
    if x > max_exp:
        x = max_exp
    elif x < -max_exp:
        x = -max_exp
    return math.exp(x)

def acceptance_probability(delta, temperature):
    scaled_delta = delta / temperature
    return safe_exp(-scaled_delta)

# Simulated Annealing
def simulated_annealing(initial_solution, initial_temperature, cooling_rate, max_iterations):
    current_solution = initial_solution
    best_solution = current_solution
    current_temperature = initial_temperature

    for iteration in range(max_iterations):
        # Gerar uma solução vizinha
        neighbor_solution = get_neighbor(current_solution, step_size=1)

        # Verificar se a solução vizinha é válida
        if constraints(*neighbor_solution):
            # Calcular as diferenças de custo entre as soluções
            current_cost = objective_function(*current_solution)
            neighbor_cost = objective_function(*neighbor_solution)
            cost_difference = neighbor_cost - current_cost

            # Verificar se a solução vizinha é melhor ou se deve ser aceita com uma probabilidade decrescente
            if cost_difference > 0 or acceptance_probability(cost_difference, current_temperature) > random.uniform(0, 1):
                current_solution = neighbor_solution

                # Atualizar a melhor solução encontrada
                if neighbor_cost > objective_function(*best_solution):
                    best_solution = neighbor_solution

        # Diminuir a temperatura
        current_temperature *= cooling_rate

    return best_solution

# Parâmetros do Simulated Annealing
initial_solution = [random.uniform(0, 36), random.uniform(0, 50)]
initial_temperature = 1000
cooling_rate = 0.80
max_iterations = 1000000

start = time.time()
# Executar o Simulated Annealing
best_solution = simulated_annealing(initial_solution, initial_temperature, cooling_rate, max_iterations)

end = time.time()
print((end - start)*1000)

# Exibir a melhor solução encontrada
print("Melhor solução encontrada:")
print("x1 =", best_solution[0])
print("x2 =", best_solution[1])
print("Valor da função de custo:", objective_function(*best_solution))