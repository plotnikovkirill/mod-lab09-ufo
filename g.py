import matplotlib.pyplot as plt
import numpy as np
from matplotlib.colors import LinearSegmentedColormap


def read_data(filename):
    n_values = []
    err_values = []
    with open(filename, 'r') as file:
        for line in file:
            line = line.strip()
            if line and not line.startswith('#'):
                parts = line.split()
                n = int(parts[0])
                err = float(parts[1].replace(',', '.'))
                n_values.append(n)
                err_values.append(err)
    return n_values, err_values


def plot_err_vs_n(n_values, err_values, output_file='polar_plot.png'):
    # Создаем кастомную цветовую карту
    colors = ["#2a9d8f", "#e9c46a", "#f4a261", "#e76f51"]
    cmap = LinearSegmentedColormap.from_list("error_cmap", colors)

    # Создаем фигуру с полярной проекцией
    plt.figure(figsize=(14, 10))
    ax = plt.subplot(111, polar=True)

    # Рассчитываем углы для каждого значения n
    angles = np.linspace(0, 2 * np.pi, len(n_values), endpoint=False)

    # Нормализуем ошибки для цветового отображения
    norm_errors = np.array(err_values) / max(err_values)
    colors = cmap(norm_errors)

    # Рисуем столбцы
    bars = ax.bar(angles, height=1.0, width=0.4,
                  bottom=0.2, color=colors, alpha=0.85,
                  edgecolor='white', linewidth=2)

    # Добавляем метки значений
    for angle, n, err, bar in zip(angles, n_values, err_values, bars):
        # Поворачиваем подписи
        rotation = np.degrees(angle)
        ha = "left"
        if angle >= np.pi / 2 and angle < 3 * np.pi / 2:
            rotation += 180
            ha = "right"

        # Добавляем текст
        ax.text(angle, 1.5, f"n={n}\nerr={err:.2e}",
                ha=ha, va='center', rotation=rotation,
                fontsize=9, fontweight='bold',
                bbox=dict(boxstyle='round,pad=0.3',
                          facecolor='white',
                          alpha=0.8,
                          edgecolor='none'))

    # Настраиваем вид графика
    ax.set_theta_offset(np.pi / 2)
    ax.set_theta_direction(-1)
    ax.set_rticks([0, 0.5, 1.0])
    ax.set_yticklabels([])
    ax.set_xticks(angles)
    ax.set_xticklabels(n_values, fontsize=10, fontweight='bold')
    ax.grid(True, color='gray', linestyle='--', alpha=0.3)
    ax.set_axisbelow(True)

    # Добавляем заголовок и легенду
    plt.title('Распределение ошибки по значениям n (полярная проекция)',
              fontsize=16,
              fontweight='bold',
              pad=30)

    # Добавляем цветовую шкалу
    sm = plt.cm.ScalarMappable(cmap=cmap,
                               norm=plt.Normalize(min(err_values), max(err_values)))
    sm.set_array([])
    cbar = plt.colorbar(sm, ax=ax, pad=0.08, shrink=0.7)
    cbar.set_label('Величина ошибки', fontsize=12)
    cbar.ax.tick_params(labelsize=9)

    # Сохраняем
    plt.savefig(output_file, dpi=350, bbox_inches='tight', facecolor='white')
    plt.close()


if __name__ == "__main__":
    input_filename = 'result/data.txt'
    output_filename = 'result/polar_plot.png'

    n_values, err_values = read_data(input_filename)
    plot_err_vs_n(n_values, err_values, output_filename)

    print(f"Полярная диаграмма сохранена как {output_filename}")