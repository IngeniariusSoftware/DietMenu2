select food.ingestion_name as Трапеза,
       food.dish_name as Блюдо,
       round(sum(food.proteins)) as Белков,
       round(sum(food.fats)) as Жиров ,
       round(sum(food.carbohydrates)) as Углеводов,
       round(sum(food.calories)) as Калорий
from

    (
	 select it.ingestion_type_name as ingestion_name,
            d.dish_name as dish_name,
            p.proteins * pld.product_proportion * es.portion as proteins,
            p.fats * pld.product_proportion * es.portion as fats,
            p.carbohydrates * pld.product_proportion * es.portion  as carbohydrates,
            p.calories * pld.product_proportion * es.portion  as calories
     from ingestion_types it,
          eating_sessions es,
          dishes d,
          products p,
          product_link_dish pld
     where es.user_id = @userid
       and es.time_stamp = current_date
       and es.ingestion_type_id = it.ingestion_type_id
       and d.dish_id = es.dish_id
       and pld.dish_id = d.dish_id
       and pld.product_id = p.product_id
	) 
	as food

group by food.ingestion_name,
         food.dish_name