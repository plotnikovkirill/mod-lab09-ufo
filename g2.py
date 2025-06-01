import matplotlib.pyplot as plt
import numpy as np
from matplotlib.colors import LinearSegmentedColormap
from matplotlib.ticker import FuncFormatter, LogLocator


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


def plot_err_vs_n(n_values, err_values, output_file='gradient_plot.png'):
    # Создаем фигуру с улучшенной композицией
    plt.figure(figsize=(14, 8))
    ax = plt.subplot(111)

    # Создаем кастомный градиентный цвет
    cmap = LinearSegmentedColormap.from_list("gradient", ["#0077b6", "#90e0ef"])

    # Нормализуем значения ошибок для цветового отображения
    norm_errors = (np.array(err_values) - min(err_values)) / (max(err_values) - min(err_values))
    colors = [cmap(1 - err) for err in norm_errors]  # Инвертируем для лучших значений

    # Рисуем столбцы с градиентной заливкой
    bars = plt.bar(n_values, err_values,
                   color=colors,
                   edgecolor='#03045e',
                   linewidth=1.5,
                   width=0.7,
                   alpha=0.85,
                   zorder=3)

    # Добавляем значения ошибок над столбцами
    for i, (n, err) in enumerate(zip(n_values, err_values)):
        plt.text(n, err * 1.05, f'{err:.1e}',
                 ha='center', va='bottom',
                 fontsize=9, fontweight='bold',
                 rotation=45)

    # Настраиваем фон и сетку
    ax.set_facecolor('#f8f9fa')
    plt.grid(axis='y', linestyle='--', alpha=0.7, color='#adb5bd', zorder=0)

    # Настраиваем оси
    plt.yscale('log')
    plt.xticks(n_values, fontsize=10)
    plt.xlabel('Количество членов ряда (n)', fontsize=12, fontweight='bold', labelpad=10)
    plt.ylabel('Ошибка аппроксимации (log scale)', fontsize=12, fontweight='bold', labelpad=10)

    # Форматируем ось Y для лучшей читаемости
    ax.yaxis.set_major_formatter(FuncFormatter(lambda y, _: '{:.0e}'.format(y)))

    # Добавляем горизонтальные линии для уровней ошибок
    levels = np.logspace(np.floor(np.log10(min(err_values))),
                         np.ceil(np.log10(max(err_values))),
                         5)
    for level in levels:
        plt.axhline(y=level, color='#495057', linestyle=':', alpha=0.4, linewidth=0.8)

    # Добавляем заголовок
    plt.title('Влияние количества членов ряда на точность аппроксимации',
              fontsize=16,
              fontweight='bold',
              pad=20,
              color='#212529')

    # Добавляем цветовую легенду
    sm = plt.cm.ScalarMappable(cmap=cmap,
                               norm=plt.Normalize(min(err_values), max(err_values)))
    sm.set_array([])
    cbar = plt.colorbar(sm, ax=ax, shrink=0.8, pad=0.02)
    cbar.set_label('Значение ошибки', fontsize=10)
    cbar.ax.tick_params(labelsize=8)

    # Добавляем аннотацию для лучшего значения
    min_idx = err_values.index(min(err_values))
    plt.annotate(f'Оптимальное n: {n_values[min_idx]}\nОшибка: {min(err_values):.1e}',
                 xy=(n_values[min_idx], min(err_values)),
                 xytext=(n_values[min_idx] + 0.5, min(err_values) * 10),
                 arrowprops=dict(arrowstyle='->', color='#d00000', linewidth=1.5),
                 bbox=dict(boxstyle='round,pad=0.5', fc='#ffd166', ec='#d00000', alpha=0.9),
                 fontsize=10, fontweight='bold')

    # Настраиваем пределы оси Y
    plt.ylim(min(err_values) * 0.8, max(err_values) * 1.2)

    # Сохраняем с высоким разрешением
    plt.tight_layout()
    plt.savefig(output_file, dpi=350, bbox_inches='tight')
    plt.close()


if __name__ == "__main__":
    input_filename = 'result/data.txt'
    output_filename = 'result/gradient_bars_plot.png'

    n_values, err_values = read_data(input_filename)
    plot_err_vs_n(n_values, err_values, output_filename)

    print(f"График с градиентными столбцами сохранен как {output_filename}")