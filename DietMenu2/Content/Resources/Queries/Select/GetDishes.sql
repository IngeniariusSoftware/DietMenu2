select food.dish_name as Блюдо,
       round(sum(food.proteins)) as Белки,
       round(sum(food.fats)) as Жиры ,
       round(sum(food.carbohydrates)) as Углеводы,
       round(sum(food.calories)) as Калории
from

    (
	 select d.dish_name as dish_name,
            p.proteins * pld.product_proportion as proteins,
            p.fats * pld.product_proportion as fats,
            p.carbohydrates * pld.product_proportion  as carbohydrates,
            p.calories * pld.product_proportion  as calories
     from dishes d,
          products p,
          product_link_dish pld
     where pld.dish_id = d.dish_id
       and pld.product_id = p.product_id
	) 
	as food

group by food.dish_name